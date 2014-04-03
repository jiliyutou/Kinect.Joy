using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

using System.Windows.Threading;
using FluidKit.Controls;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Kinect.Joy.Share;

namespace Kinect.Joy
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensorChooser sensorChooser;
        private readonly DispatcherTimer repeatTimer;


        private List<string> _supported;
        private List<string> _images;
        private string[] _videofmts;
        FrameworkElement _backelem;
        FrameworkElement _previtem;
        private bool _refresh;
        private void TransPres_TransitionCompleted(object sender, EventArgs e)
        {
            if (_backelem is IViev)
            {
                if (_previtem is IViev)
                {
                    IViev old = (IViev)_previtem;
                    old.ClearItems();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
                IViev v = (IViev)_backelem;
                v.ClearItems();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                v.Fill(_images.ToArray());
                if (_refresh) _refresh = false;
            }
        }
        public bool IsVideo(string file)
        {
            string ext = "*" + System.IO.Path.GetExtension(file);
            return _videofmts.Contains(ext);
        }
        private void SetView()
        {
            Random r = new Random();
            int index = r.Next(0, 4);
            TransRotat.Rotation = (FluidKit.Controls.Direction)index;
        }

        public KinectSensor Sensor
        {
            get
            {
                return sensorChooser.Kinect;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeView3D();

            // initialize the sensor chooser and UI
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooser.Start();

            // Bind the sensor chooser's current sensor to the KinectRegion
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);

            repeatTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(3000) };
            repeatTimer.Tick += new EventHandler(repeatTimer_Tick);

        }

        /// <summary>
        /// Load Images to memory automatically when mainWindow finishes Loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KinectJoyMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string _directory = System.AppDomain.CurrentDomain.BaseDirectory + "Image";
            if (string.IsNullOrEmpty(_directory)) return;
            string[] tmp;
            _images.Clear();
            try
            {
                foreach (var type in _supported)
                {
                    tmp = System.IO.Directory.GetFiles(_directory, type);
                    _images.AddRange(tmp);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can't open folder.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _images.Sort();
            SetView();
            _refresh = true;
            _previtem = _backelem;
            TransPres.ApplyTransition(_previtem, _backelem);
        }

        private void InitializeView3D()
        {
            App.MainWin = this;
            App.Taskbar = new Win7Integrator();
            App.Shell = new WinShellWraper();
            _images = new List<string>();
            _supported = new List<string>
            {
                "*.jpg", "*.jpeg", "*.bmp", "*.png", "*.tiff", "*.wdp"
            };
            _videofmts = new string[]
            {
                "*.avi", "*.mpg", "*.mpeg", "*.mp4", "*.m4v"
            };
            _refresh = false;
            _supported.AddRange(_videofmts);
            if (App.Shell.WebPInstalled()) _supported.Add("*.webp");
            _backelem = VFlow;
        }

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void KinectJoyMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.sensorChooser.Stop();
        }

        /// <summary>
        /// Called when the KinectSensorChooser gets a new sensor
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="args">event arguments</param>
        private static void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();

                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }
        }

        /// <summary>
        /// Left Page KinectHoverButton Click Event  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageLeftButtonClick(object sender, RoutedEventArgs e)
        {
            int currIndex = VFlow.SelectedIndex;
            if (currIndex - 1 >= 0)
                VFlow.SelectedIndex = currIndex - 1;

        }
        
        /// <summary>
        /// Right Page KinectHoverButton Click Event  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageRightButtonClick(object sender, RoutedEventArgs e)
        {
            int currIndex = VFlow.SelectedIndex;
            if (currIndex + 1 <= VFlow.ItemCount - 1)
                VFlow.SelectedIndex = currIndex + 1;
        }

        /// <summary>
        /// WeiBo Button Click Event, share image to Sina weibo
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
                    weiboShare.Share2Weibo(_images[VFlow.SelectedIndex]);
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
        private void repeatTimer_Tick(object sender, EventArgs e)
        {
            if (!this.WeiboTips.Content.Equals(""))
            {
                this.WeiboTips.Content = "";
                this.repeatTimer.Stop();
            }
        }

        
        /// <summary>
        /// 3D Image View mode change click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static int styleIndex = 0;
        private void StyleBtn_Click(object sender, RoutedEventArgs e)
        {
            styleIndex = (++styleIndex) % 3;
            switch (styleIndex)
            {
                case 0:
                    this.VFlow.EFlowLayout = new CoverFlow();
                    break;
                case 1:
                    this.VFlow.EFlowLayout = new VForm();
                    break;
                case 2:
                    this.VFlow.EFlowLayout = new TimeMachine();
                    break;
            }
        }

        private void FullScreenBtn_Click(object sender, RoutedEventArgs e)
        {
            FullView viewFull = new FullView(this);
            viewFull.Images = this._images.ToArray();
            viewFull.StartIndex = VFlow.SelectedIndex;
            this.RootLayout.Children.Add(viewFull);
        }

        private void CameraBtn_Click(object sender, RoutedEventArgs e)
        {
            CameraView cameraView = new CameraView(this);
            cameraView._images = this._images;
            this.RootLayout.Children.Add(cameraView);
        }
        
    }
}
