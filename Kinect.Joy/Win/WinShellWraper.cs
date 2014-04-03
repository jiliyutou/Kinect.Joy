using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows.Media.Imaging;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace Kinect.Joy
{
    public class WinShellWraper
    {
        private ShellObject _shellitem;
        private bool _shellsupport;

        public WinShellWraper()
        {
            _shellsupport = ShellObject.IsPlatformSupported;
        }

        #region Thumbnails
        private BitmapSource FailSafeThumbnail(string path)
        {
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.DecodePixelWidth = 200;
            bmi.UriSource = new Uri(path);
            bmi.EndInit();
            bmi.Freeze();
            return bmi;
        }

        public BitmapSource GetThumbnail(string path)
        {
            try
            {
                if (_shellsupport)
                {
                    _shellitem = ShellObject.FromParsingName(path);
                    BitmapSource ret = _shellitem.Thumbnail.LargeBitmapSource;
                    _shellitem.Dispose();
                    _shellitem = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    return ret;
                }
                else return FailSafeThumbnail(path);
            }
            catch (Exception)
            {
                return FailSafeThumbnail(path);
            }
        }
        #endregion

        public int GetExifRotationInfo(string path)
        {
            if (!_shellsupport) return 1;
            _shellitem = ShellObject.FromParsingName(path);
            object res = 1;
            foreach (var item in _shellitem.Properties.DefaultPropertyCollection)
            {
                if (item.CanonicalName == "System.Photo.Orientation")
                {
                    res = item.ValueAsObject;
                    break;
                }
            }
            _shellitem.Dispose();
            _shellitem = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            return Convert.ToInt32(res);
        }

        #region Dialogs
        public string OpenDirectory(string InitialPath)
        {
            if (Environment.OSVersion.Version.Major <= 6 && Environment.OSVersion.Version.Minor < 1)
            {
                System.Windows.Forms.FolderBrowserDialog fb = new System.Windows.Forms.FolderBrowserDialog();
                if (!string.IsNullOrEmpty(InitialPath)) fb.SelectedPath = InitialPath;
                if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK) return fb.SelectedPath;
                else return null;
            }
            else
            {
                CommonOpenFileDialog cfd = new CommonOpenFileDialog();
                cfd.EnsureReadOnly = true;
                cfd.IsFolderPicker = true;
                cfd.EnsurePathExists = true;
                cfd.AllowNonFileSystemItems = true;
                if (!string.IsNullOrEmpty(InitialPath)) cfd.InitialDirectory = InitialPath;
                if (cfd.ShowDialog() == CommonFileDialogResult.Ok) return cfd.FileName;
                else return null;
            }
        }

        public bool IsVirtualPath(string path)
        {
            return path.Contains("::{");
        }

        public bool WebPInstalled()
        {
            string pf = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            return File.Exists(pf + @"\WebP Codec\WebpWICCodec.dll");
        }
        #endregion
    }
}
