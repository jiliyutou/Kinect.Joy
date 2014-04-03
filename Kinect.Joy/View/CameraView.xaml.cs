using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Kinect.Joy
{
    using System.Media;
    using System.Windows;
    using System.Windows.Shapes;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;   
    using System.Windows.Threading;
    using Microsoft.Kinect;
    using Kinect.Joy.Share;
    using Kinect.FingerTracking;

    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class CameraView : UserControl
    {
        private KinectSensorPlus SensorPlus;
        private MainWindow mainWindow;
        
        private const int COUNT_DOWN = 5;
        private const double COUNT_INTERVAL = 1000d;
        private readonly DispatcherTimer repeatTimer;
        private readonly DispatcherTimer shutterTimer;
        private int TickCount = COUNT_DOWN;

        public List<string> _images { get; set; }


        private SolidColorBrush BoneBrush = new SolidColorBrush(Colors.Red);
        private SolidColorBrush JointBrush = new SolidColorBrush(Colors.Gray);
        private Color[] FingerColor = new Color[5] { Colors.Red, Colors.Orange, Colors.Black, Colors.Green, Colors.Blue};
        private Dictionary<FingerType, List<PointSkeleton3D>> Dict;      //Dict for piano player


        public CameraView(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.UserViewer = mainWindow.UserViewer;

            InitializeKinectPlus();
            shutterTimer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(COUNT_INTERVAL) };
            shutterTimer.Tick += new EventHandler(shutterTimer_Tick);
            repeatTimer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(3000d) };
            repeatTimer.Tick += new EventHandler(repeatTimer_Tick);
        }

        private void InitializeKinectPlus()
        {
            this.SensorPlus = new KinectSensorPlus(mainWindow.Sensor);
            this.SensorPlus.CurrViewType = ViewEnum.CameraView;
            this.SensorPlus.DrawSkeletonAndFingers = OnDrawSkeletonAndFingers;
            this.SensorPlus.PlayPiano = OnPlayPiano;
            this.ImgCurrent.Source = this.SensorPlus.ColorBitmap;
            //Inititialize Dict
            Dict = new Dictionary<FingerType, List<PointSkeleton3D>>();
            Dict.Add(FingerType.ThumbRight, new List<PointSkeleton3D>(200));
            Dict.Add(FingerType.IndexRight, new List<PointSkeleton3D>(200));
            Dict.Add(FingerType.MiddleRight, new List<PointSkeleton3D>(200));
            Dict.Add(FingerType.RingRight, new List<PointSkeleton3D>(200));
            Dict.Add(FingerType.LittleRight, new List<PointSkeleton3D>(200));
        }

        private string SaveImage()
        {
            string _directory = System.AppDomain.CurrentDomain.BaseDirectory + "Image\\";
            string fileName = _directory + System.DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".jpg";
            if (string.IsNullOrEmpty(_directory))
                return null;
            KinectJoyUtil.SaveToImage(this.SensorPlus.ColorBitmap, fileName);
            return fileName;
        }

        private void TransPres_TransitionCompleted(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SensorPlus.ReleaseFrameReady();
            mainWindow.RootLayout.Children.Remove(this);
        }

        private WriteableBitmap overviewBitmap;
        private string overviewFilename;
        private void CameraBtn_Click(object sender, RoutedEventArgs e)
        {
            shutterTimer.Start();
            this.OverviewImage.Source = null;
            CountDownLable.Content = COUNT_DOWN.ToString();
        }

        /// <summary>
        /// Count down and play sound before taking picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void shutterTimer_Tick(object sender, EventArgs e)
        {
            shutterTimer.Stop();
            TickCount--;
            if (TickCount == 0)
            {
                SoundPlayer soundPlayer = new SoundPlayer(Kinect.Joy.Properties.Resources.shutter);
                soundPlayer.Play();
                overviewFilename = SaveImage();
                //_images.Add(overviewFilename);      //需要同步更新FullView和CameraView
                TickCount = COUNT_DOWN;
                CountDownLable.Content = "";
                overviewBitmap = new WriteableBitmap(this.SensorPlus.ColorBitmap);
                this.OverviewImage.Source = overviewBitmap;
                this.WeiboBtn.Visibility = Visibility.Visible;
            }
            else
            {
                CountDownLable.Content = TickCount.ToString();
                SoundPlayer soundPlayer = new SoundPlayer(Kinect.Joy.Properties.Resources.tick);
                soundPlayer.Play();
                shutterTimer.Start();
            }
        }

        /// <summary>
        /// Share current overview photo to Sina Weibo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeiboBtn_Click(object sender, RoutedEventArgs e)
        {
            WeiboShare weiboShare = new WeiboShare();
            switch (weiboShare.Login())
            {
                case LoginType.Success:
                    this.WeiboTips.Content = "Share Image Success.";
                    weiboShare.Share2Weibo(overviewFilename);
                    this.repeatTimer.Start();
                    break;
                case LoginType.AuthFailed:
                    this.WeiboTips.Content = "Error! Network Disconnect!";
                    this.repeatTimer.Start();
                    break;
                case LoginType.LoginFailed:
                    this.WeiboTips.Content = "UserId and Password don't match!";
                    this.repeatTimer.Start();
                    break;
            }

            this.CountDownLable.Content = COUNT_DOWN.ToString();
            this.OverviewImage.Source = null;
            this.WeiboBtn.Visibility = Visibility.Hidden;
        }
        private void repeatTimer_Tick(object sender, EventArgs e)
        {
            if (!this.WeiboTips.Content.Equals(""))
            {
                this.WeiboTips.Content = "";
                this.repeatTimer.Stop();
            }
        }

        #region Draw OnDrawSkeletonAndFingers
        /// <summary>
        /// Map Joint Position to ColorImagePoint 
        /// </summary>
        /// <param name="joint"></param>
        /// <returns></returns>
        private Point getDisplayPosition(Joint joint)
        {
            CoordinateMapper mapper = new CoordinateMapper(this.SensorPlus.Sensor);
            ColorImagePoint point = mapper.MapSkeletonPointToColorPoint(joint.Position, this.SensorPlus.Sensor.ColorStream.Format);
            return new Point(point.X, point.Y);
        }

        /// <summary>
        /// Get bone polyline of one skeleton 
        /// </summary>
        /// <param name="joints"></param>
        /// <param name="brush"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        private Polyline getBodySegment(JointCollection joints, Brush brush, params JointType[] ids)
        {
            PointCollection collection = new PointCollection(ids.Length);
            for (int i = 0; i < ids.Length; i++)
            {
                collection.Add(getDisplayPosition(joints[ids[i]]));
            }
            Polyline polyline = new Polyline();
            polyline.Points = collection;
            polyline.Stroke = brush;
            polyline.StrokeThickness = 5;
            return polyline;
        }

        /// <summary>
        /// Draw Skeleton and Fingertips, handler of KinectSensorPlus'delegate event 
        /// </summary>
        /// <param name="sk"></param>
        [MTAThread]
        private void OnDrawSkeletonAndFingers(Skeleton sk, FingerIdentification Fingers)
        {
            this.Skel_Canvas.Children.Clear();
            OnDrawSkeleton(sk);
            OnDrawFingerTips(Fingers);
        }

        /// <summary>
        /// Draw Skeleton
        /// </summary>
        /// <param name="sk"></param>
        private void OnDrawSkeleton(Skeleton sk)
        {
            if (null != sk && sk.TrackingState == SkeletonTrackingState.Tracked)
            {
                this.Skel_Canvas.Children.Add(getBodySegment(sk.Joints, BoneBrush, JointType.Head, JointType.ShoulderCenter, JointType.Spine, JointType.HipCenter));
                this.Skel_Canvas.Children.Add(getBodySegment(sk.Joints, BoneBrush, JointType.ShoulderCenter, JointType.ShoulderLeft, JointType.ElbowLeft, JointType.WristLeft, JointType.HandLeft));
                this.Skel_Canvas.Children.Add(getBodySegment(sk.Joints, BoneBrush, JointType.ShoulderCenter, JointType.ShoulderRight, JointType.ElbowRight, JointType.WristRight, JointType.HandRight));
                this.Skel_Canvas.Children.Add(getBodySegment(sk.Joints, BoneBrush, JointType.HipCenter, JointType.HipLeft, JointType.KneeLeft, JointType.AnkleLeft, JointType.FootLeft));
                this.Skel_Canvas.Children.Add(getBodySegment(sk.Joints, BoneBrush, JointType.HipCenter, JointType.HipRight, JointType.KneeRight, JointType.AnkleRight, JointType.FootRight));

                foreach (Joint joint in sk.Joints)
                {
                    Ellipse ellipse = new Ellipse() { Stroke = JointBrush, StrokeThickness = 5 };
                    this.Skel_Canvas.Children.Add(ellipse);
                    Point point = getDisplayPosition(joint);
                    ellipse.SetValue(Canvas.LeftProperty, point.X);
                    ellipse.SetValue(Canvas.TopProperty, point.Y);
                }
            }
        }

        /// <summary>
        /// Draw Fingertips
        /// </summary>
        /// <param name="Fingers"></param>
        private void OnDrawFingerTips(FingerIdentification Fingers)
        {
            if (Fingers == null)
                return;
            if (Fingers[FingerType.ThumbRight].TrackingState == FingerTrackingState.Tracked)
            {
                Ellipse ellipse = new Ellipse() { Stroke = new SolidColorBrush(FingerColor[0]), StrokeThickness = 5, Height = 10, Width = 10 };
                this.Skel_Canvas.Children.Add(ellipse);
                Point2D position = Fingers.GetPoint2Position(FingerType.ThumbRight);
                Canvas.SetLeft(ellipse, position.X);
                Canvas.SetTop(ellipse, position.Y);
            }

            if (Fingers[FingerType.IndexRight].TrackingState == FingerTrackingState.Tracked)
            {
                Ellipse ellipse = new Ellipse() { Stroke = new SolidColorBrush(FingerColor[1]), StrokeThickness = 5, Height = 10, Width = 10 };
                this.Skel_Canvas.Children.Add(ellipse);
                Point2D position = Fingers.GetPoint2Position(FingerType.IndexRight);

                Canvas.SetLeft(ellipse, position.X);
                Canvas.SetTop(ellipse, position.Y);
            }
            if (Fingers[FingerType.MiddleRight].TrackingState == FingerTrackingState.Tracked)
            {
                Ellipse ellipse = new Ellipse() { Stroke = new SolidColorBrush(FingerColor[2]), StrokeThickness = 5, Height = 10, Width = 10 };
                this.Skel_Canvas.Children.Add(ellipse);
                Point2D position = Fingers.GetPoint2Position(FingerType.MiddleRight);
                Canvas.SetLeft(ellipse, position.X);
                Canvas.SetTop(ellipse, position.Y);
            }
            if (Fingers[FingerType.RingRight].TrackingState == FingerTrackingState.Tracked)
            {
                Ellipse ellipse = new Ellipse() { Stroke = new SolidColorBrush(FingerColor[3]), StrokeThickness = 5, Height = 10, Width = 10 };
                this.Skel_Canvas.Children.Add(ellipse);
                Point2D position = Fingers.GetPoint2Position(FingerType.RingRight);

                Canvas.SetLeft(ellipse, position.X);
                Canvas.SetTop(ellipse, position.Y);
            }
            if (Fingers[FingerType.LittleRight].TrackingState == FingerTrackingState.Tracked)
            {
                Ellipse ellipse = new Ellipse() { Stroke = new SolidColorBrush(FingerColor[4]), StrokeThickness = 5, Height = 10, Width = 10 };
                this.Skel_Canvas.Children.Add(ellipse);
                Point2D position = Fingers.GetPoint2Position(FingerType.LittleRight);
                Canvas.SetLeft(ellipse, position.X);
                Canvas.SetTop(ellipse, position.Y);
            }
        }

        #endregion 

        
        private void Add(FingerType type, FingerIdentification Fingers)
        {
            if (Fingers[type].TrackingState == FingerTrackingState.Tracked)
            {
                Dict[type].Add(Fingers[type].Position);
            }
        }

        private void OnPlayPiano(FingerIdentification Fingers)
        {
            if (Fingers == null)
                return;
            foreach (var i in Enum.GetValues(typeof(FingerType)))
            {
                FingerType type = (FingerType)i;
                if (Fingers[type].TrackingState == FingerTrackingState.Tracked)
                {
                    Dict[type].Add(Fingers[type].Position);
                    if (Dict[type].Count > 30)
                    {
                        int index = Dict[type].Count - 1;
                        if (Dict[type][index - 30].Z - Dict[type][index].Z > 0.015d)    //当前点和第前30个点，指尖点击距离超过15mm
                        {
                            SoundPlayer soundPlayer;
                            switch (type)
                            {
                                case FingerType.ThumbRight:
                                    soundPlayer = new SoundPlayer(Kinect.Joy.Properties.Resources._08___C);
                                    soundPlayer.Play();
                                    break;
                                case FingerType.IndexRight:
                                    soundPlayer = new SoundPlayer(Kinect.Joy.Properties.Resources._09___D);
                                    soundPlayer.Play();
                                    break;
                                case FingerType.MiddleRight:
                                    soundPlayer = new SoundPlayer(Kinect.Joy.Properties.Resources._10___E);
                                    soundPlayer.Play();
                                    break;
                                case FingerType.RingRight:
                                    soundPlayer = new SoundPlayer(Kinect.Joy.Properties.Resources._11___F);
                                    soundPlayer.Play();
                                    break;
                                case FingerType.LittleRight:
                                    soundPlayer = new SoundPlayer(Kinect.Joy.Properties.Resources._12___G);
                                    soundPlayer.Play();
                                    break;
                            }
                            Dict[type].Clear();
                        }
                    }
                }
            }
        }

    }
}
