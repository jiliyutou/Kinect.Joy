using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kinect.Joy
{
    using System.Windows.Threading;
    using System.Windows.Media.Animation;
    using ImageView.Shaders;
    using Kinect.Joy.Share;
    using Microsoft.Kinect.Toolkit.Controls;
    using Microsoft.Samples.Kinect.SwipeGestureRecognizer;

    /// <summary>
    /// FullImageView.xaml 的交互逻辑
    /// </summary>
    public partial class FullView : UserControl
    {
        private MainWindow mainWindow;
        private KinectSensorPlus SensorPlus;

        private readonly DispatcherTimer repeatTimer;
        private const double LABLE_DISAPPEAR_SEC = 3000d;

        private EffectManager _em;
        private BitmapSource _current;
        private BitmapSource _next;
        private int i;
        private string[] _images;

        public FullView(MainWindow mainWindow)
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                _em = new EffectManager();
                i = 0;
            }
            this.mainWindow = mainWindow;
            this.UserViewer = mainWindow.UserViewer;

            InitializeKinectPlus();
            repeatTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(LABLE_DISAPPEAR_SEC) };
            repeatTimer.Tick += new EventHandler(repeatTimer_Tick);
        }

        private void InitializeKinectPlus()
        {
            this.SensorPlus = new KinectSensorPlus(mainWindow.Sensor);
            this.SensorPlus.CurrViewType = ViewEnum.FullView;
            this.SensorPlus.activeRecognizer = new Recognizer();
            this.SensorPlus.activeRecognizer.SwipeLeftDetected += new EventHandler<KinectGestureEventArgs>(OnSwipeLeftDetected);
            this.SensorPlus.activeRecognizer.SwipeRightDetected += new EventHandler<KinectGestureEventArgs>(OnSwipeRightDetected);
        }

        public string[] Images
        {
            get { return _images; }
            set
            {
                _images = value;
            }
        }

        public int StartIndex
        {
            get { return i; }
            set
            {
                if (i < 0 || i > Images.Length) 
                    throw new IndexOutOfRangeException();
                i = value;
                SetImage();
            }
        }

        private void SetImage()
        {
            DisposeUnused();
            _current = getImg(Images[i], true);
            _next = getImg(Images[i], true);
            AplyEffect();
            ImgCurrent.Source = _next;
            SetRotation(Images[i]);
        }

        private void DisposeUnused()
        {
            ImgCurrent.Source = null;
            if (_current != null) _current = null;
            if (_next != null) _next = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private BitmapSource getImg(string path, bool small)
        {
            if (App.MainWin.IsVideo(path)) return App.Shell.GetThumbnail(path);

            BitmapImage ret = new BitmapImage();
            ret.BeginInit();
            ret.UriSource = new Uri(path);
            if (small)
            {
                ret.DecodePixelWidth = (int)(System.Windows.SystemParameters.PrimaryScreenWidth * 0.8);
            }
            ret.CacheOption = BitmapCacheOption.OnLoad;
            ret.EndInit();
            ret.Freeze();
            return ret;
        }

        private void AplyEffect()
        {
            TransitionEffect fx = _em.GetEffect();
            fx.Progress = 0;
            fx.OldImage = new ImageBrush(_current);
            fx.OldImage.Freeze();
            ImgCurrent.Effect = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            ImgCurrent.Effect = fx;

            DoubleAnimation da = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(1.5)), FillBehavior.HoldEnd);
            da.AccelerationRatio = 0.5;
            da.DecelerationRatio = 0.5;
            da.Completed += new EventHandler(da_Completed);
            fx.BeginAnimation(TransitionEffect.ProgressProperty, da);
        }

        private void da_Completed(object sender, EventArgs e)
        {
        }

        private void SetRotation(string file)
        {
            int rot = App.Shell.GetExifRotationInfo(file);
            ImgRot.Angle = 0;
            ImgScale.ScaleX = 1;
            ImgScale.ScaleY = 1;
            switch (rot)
            {
                case 2:
                    ImgScale.ScaleY = -1;
                    break;
                case 3:
                    ImgRot.Angle = -180;
                    break;
                case 4:
                    ImgScale.ScaleX = -1;
                    break;
                case 5:
                    ImgRot.Angle = 90;
                    ImgScale.ScaleY = -1;
                    break;
                case 6:
                    ImgRot.Angle = 90;
                    break;
                case 7:
                    ImgRot.Angle = -90;
                    ImgScale.ScaleY = -1;
                    break;
                case 8:
                    ImgRot.Angle = -90;
                    break;
            }
        }

        private void TransPres_TransitionCompleted(object sender, EventArgs e)
        {
 
        }
        
        private void ShowPreImage()
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                int next = i - 1;
                if (i - 1 < 0) next = Images.Length - 1;

                DisposeUnused();

                _current = getImg(Images[i], true);
                _next = getImg(Images[next], true);
                AplyEffect();
                ImgCurrent.Source = _next;
                SetRotation(Images[next]);
                --i;
                if (i < 0) i = Images.Length - 1;
                mainWindow.VFlow.SelectedIndex = i;
            }
        }
        
        private void ShowNextImage()
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                int next = i + 1;
                if (i + 1 > Images.Length - 1) next = 0;

                DisposeUnused();

                _current = getImg(Images[i], true);
                _next = getImg(Images[next], true);
                AplyEffect();
                ImgCurrent.Source = _next;
                SetRotation(Images[next]);
                ++i;
                if (i > Images.Length - 1) i = 0;
                mainWindow.VFlow.SelectedIndex = i;
            }
        }

        private void PreBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowPreImage();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowNextImage();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SensorPlus.ReleaseFrameReady();
            mainWindow.RootLayout.Children.Remove(this);
        }

        /// <summary>
        /// Share current overview photo to Sina Weibo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeiBoBtn_Click(object sender, RoutedEventArgs e)
        {
            WeiboShare weiboShare = new WeiboShare();
            switch (weiboShare.Login())
            {
                case LoginType.Success:
                    this.WeiboTips.Content = "Share Image Success.";
                    weiboShare.Share2Weibo(_images[StartIndex]);
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
        }
        void repeatTimer_Tick(object sender, EventArgs e)
        {
            if (!this.WeiboTips.Content.Equals(""))
            {
                this.WeiboTips.Content = "";
                this.repeatTimer.Stop();
            }
        }

        void OnSwipeLeftDetected(object sender, KinectGestureEventArgs e)
        {
            ShowNextImage();
        }

        void OnSwipeRightDetected(object sender, KinectGestureEventArgs e)
        {
            ShowPreImage();
        }
    }
}
