using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Diagnostics;

namespace Kinect.Joy
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow MainWin;
        public static Win7Integrator Taskbar;
        public static WinShellWraper Shell;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                MessageBox.Show("Windows XP/Server 2003/2000 is not supported by this program.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process P = Process.GetCurrentProcess();
                P.Kill();
            }
        }
    }
}
