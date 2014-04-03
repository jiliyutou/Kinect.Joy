using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Kinect.Joy
{
    interface IViev
    {
        void Fill(string[] Items);
        void ClearItems();
        int SelectedIndex { get; }
    }
}
