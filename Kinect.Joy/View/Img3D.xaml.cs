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

namespace Kinect.Joy
{
    /// <summary>
    /// Interaction logic for Img3D.xaml
    /// </summary>
    public partial class Img3D : UserControl
    {
        public Img3D()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty ThumbImageProperty = DependencyProperty.Register("ThumbImage", typeof(ImageSource), typeof(Img3D));

        public ImageSource ThumbImage
        {
            get { return (ImageSource)GetValue(ThumbImageProperty); }
            set { SetValue(ThumbImageProperty, value); }
        }

        public void SetRotation(string file)
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

        public bool VideoIconVisible
        {
            get { return VideoIcon.IsVisible; }
            set
            {
                if (value) VideoIcon.Visibility = System.Windows.Visibility.Visible;
                else VideoIcon.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}