using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Kinect.Joy
{
    public class Win7Integrator
    {
        private TaskbarManager _taskbar;
        private bool _taskbarsupport;

        public Win7Integrator()
        {
            _taskbarsupport = TaskbarManager.IsPlatformSupported;
            if (_taskbarsupport)
            {
                _taskbar = TaskbarManager.Instance;
            }
        }

        public void SetTaskbarProgessState(TaskbarProgressBarState State)
        {
            if (!_taskbarsupport) return;
            _taskbar.SetProgressState(State);
        }

        public void SetTaskbarProgressValue(int current, int max)
        {
            if (!_taskbarsupport) return;
            _taskbar.SetProgressValue(current, max);
        }

    }
}
