using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Kinect.Joy
{
    using System.Windows.Media.Imaging;
    using System.Runtime.InteropServices;

    enum Flags
    {
        SND_SYNC = 0x0000,  /* play synchronously (default) */

        SND_ASYNC = 0x0001,  /* play asynchronously */

        SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */

        SND_MEMORY = 0x0004,  /* pszSound points to a memory file */

        SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */

        SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */

        SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */

        SND_ALIAS = 0x00010000, /* name is a registry alias */

        SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */

        SND_FILENAME = 0x00020000, /* name is file name */

        SND_RESOURCE = 0x00040004  /* name is resource name or atom */
    }

    public static class KinectJoyUtil
    {
        /// <summary>
        /// Save BitmapSource to local Jpeg
        /// </summary>
        /// <param name="Source">Image.Source</param>
        /// <param name="fileName">Image file path</param>
        public static void SaveToImage(BitmapSource Source, string fileName)
        {
            JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder();
            jpgEncoder.Frames.Add(BitmapFrame.Create(Source));
            try
            {
                using (System.IO.Stream stream = System.IO.File.Create(fileName))
                {
                    jpgEncoder.QualityLevel = 100;
                    jpgEncoder.Save(stream);
                }
            }
            catch (Exception)
            { }
        }


        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string szSound, IntPtr hMod, int flags);

        /// <summary>
        /// Play wav music according to extern directory
        /// Call form: KinectUtil.PlaySound(System.AppDomain.CurrentDomain.BaseDirectory + "Resource\\tick.wav");
        /// </summary>
        /// <param name="szSound"></param>
        public static void PlaySound(string szSound)
        {
            PlaySound(szSound,IntPtr.Zero,0x00020000 | 0x0001);
        }

    }
}
