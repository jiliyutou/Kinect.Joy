using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using FluidKit.Controls;
using System.Windows.Threading;

namespace Kinect.Joy
{
    /// <summary>
    /// Interaction logic for View3D.xaml
    /// </summary>
    public partial class View3D : UserControl, IViev
    {

        private Thread T;
        private string[] _imgs;

        public LayoutBase EFlowLayout 
        {
            get {
                return this.EFlow.Layout;
            }
            set {
                this.EFlow.Layout = value;
            }
        }

        public View3D()
        {
            this.InitializeComponent();
            EFlow.Layout = new CoverFlow();
        }

        public void ClearItems()
        {
            EFlow.Items.Clear();
        }

        public int SelectedIndex
        {
            get { 
                return EFlow.SelectedIndex; 
            }
            set {
                EFlow.SelectedIndex = value;
            }
        }

        public int ItemCount
        {
            get {
                return EFlow.Items.Count;
            }
        }

        private void DoEvents()
        {
            DispatcherFrame f = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
            (SendOrPostCallback)delegate(object arg)
            {
                DispatcherFrame fr = arg as DispatcherFrame;
                fr.Continue = false;
            }, f);
            Dispatcher.PushFrame(f);
        }

        private void ThreadFnc()
        {
            int i = 0;

            this.Dispatcher.Invoke((Action)delegate
            {
                App.Taskbar.SetTaskbarProgessState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Indeterminate);
            });
            foreach (var img in _imgs)
            {
                this.Dispatcher.Invoke((Action)delegate
                {
                    Img3D im = new Img3D();
                    //im.VideoIconVisible = App.MainWin.IsVideo(img);
                    im.ThumbImage = App.Shell.GetThumbnail(img);
                    im.SetRotation(img);
                    EFlow.Items.Add(im);
                    ++i;
                    if (i == 5)
                    {
                        DoEvents();
                        i = 0;
                    }
                });
            }
            this.Dispatcher.Invoke((Action)delegate
            {
                App.Taskbar.SetTaskbarProgessState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
                
            });
        }

        public void Fill(string[] items)
        {
            _imgs = items;
            T = new System.Threading.Thread(ThreadFnc);
            T.SetApartmentState(ApartmentState.STA);
            T.Start();
        }

        public void TerminateThread()
        {
            if (T != null)
            {
                if (T.IsAlive) T.Abort();
            }
        }
    }
}