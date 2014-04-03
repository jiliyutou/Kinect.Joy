using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using ImageView.Shaders;
using System.Reflection;
using System.Threading;
using System.IO;

namespace ImageView.Shaders
{
    internal static class Global
    {
        public static Uri MakePackUri(string relativeFile)
        {
            StringBuilder uriString = new StringBuilder(); ;
            uriString.Append("/" + AssemblyShortName + ";component/" + relativeFile);
            return new Uri(uriString.ToString(), UriKind.Relative);
        }

        private static string AssemblyShortName
        {
            get
            {
                if (_assemblyShortName == null)
                {
                    Assembly a = typeof(Global).Assembly;

                    // Pull out the short name.
                    _assemblyShortName = a.ToString().Split(',')[0];
                }

                return _assemblyShortName;
            }
        }

        private static string _assemblyShortName;
    }

    public class EffectManager
    {
        private TransitionEffect[] _Effects;
        private Random _r;
        private int _cnt;
        private string _path;

        private double RandomDouble(double min, double max)
        {
            int r = _r.Next((int)Math.Truncate(min), (int)Math.Truncate(max));
            double gen;
            do
            {
                gen = r + _r.NextDouble();
            }
            while (gen < min || gen > max);
            return gen;
        }

        private void InitilazeEffects()
        {
            SlideInTransitionEffect trans = new SlideInTransitionEffect();
            trans.SlideAmount = new System.Windows.Point(0, 1);

            SwirlTransitionEffect swirl = new SwirlTransitionEffect();
            swirl.TwistAmount = -70;

            SwirlTransitionEffect swirl2 = new SwirlTransitionEffect();
            swirl2.TwistAmount = 70;

            _Effects = new TransitionEffect[]
            {
                new CrumbleTransitionEffect(),               //0
                new DisolveTransitionEffect(),               //1
                new DropFadeTransitionEffect(),              //2
                new RadialWiggleTransitionEffect(),          //3
                new RotateCrumbleTransitionEffect(),         //4
                new WaterTransitionEffect(),                 //5
                new BandedSwirlTransitionEffect(),           //6
                new BlindsTransitionEffect(),                //7
                new BloodTransitionEffect(),                 //8
                new CircleStretchTransitionEffect(),         //9
                new FadeTransitionEffect(),                  //10
                new LeastBrightTransitionEffect(),           //11
                new LineRevealTransitionEffect(),            //12
                new MostBrightTransitionEffect(),            //13
                new PixelateTransitionEffect(),              //14
                new PixelateOutTransitionEffect(),           //15
                new RadialBlurTransitionEffect(),            //16
                new RandomCircleRevealTransitionEffect(),    //17
                new RippleTransitionEffect(),                //18
                new SaturateTransitionEffect(),              //19
                new ShrinkTransitionEffect(),                //20
                new SlideInTransitionEffect(),               //21
                trans,                                       //22
                swirl,                                       //23
                swirl2,                                      //24
                new SwirlGridTransitionEffect(),             //25
                new WaveTransitionEffect()                   //26
            };
        }

        private BitmapImage GetRandomTexture()
        {
            int index = _r.Next(1, 16);
            BitmapImage ret = new BitmapImage();
            ret.BeginInit();
            ret.UriSource = new Uri(_path + "\\Maps\\" + index.ToString() + ".jpg");
            ret.CacheOption = BitmapCacheOption.OnLoad;
            ret.EndInit();
            ret.Freeze();
            return ret;
        }

        private void RandomizeParameters()
        {
            (_Effects[0] as CrumbleTransitionEffect).CloudImage = null;
            (_Effects[1] as DisolveTransitionEffect).NoiseImage = null;
            (_Effects[2] as DropFadeTransitionEffect).CloudImage = null;
            (_Effects[3] as RadialWiggleTransitionEffect).CloudImage = null;
            (_Effects[4] as RotateCrumbleTransitionEffect).CloudImage = null;
            (_Effects[5] as WaterTransitionEffect).CloudImage = null;
            (_Effects[17] as RandomCircleRevealTransitionEffect).CloudImage = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            (_Effects[0] as CrumbleTransitionEffect).CloudImage = new ImageBrush(GetRandomTexture());
            (_Effects[1] as DisolveTransitionEffect).NoiseImage = new ImageBrush(GetRandomTexture());
            (_Effects[2] as DropFadeTransitionEffect).CloudImage = new ImageBrush(GetRandomTexture());
            (_Effects[3] as RadialWiggleTransitionEffect).CloudImage = new ImageBrush(GetRandomTexture());
            (_Effects[4] as RotateCrumbleTransitionEffect).CloudImage = new ImageBrush(GetRandomTexture());
            (_Effects[5] as WaterTransitionEffect).CloudImage = new ImageBrush(GetRandomTexture());
            (_Effects[17] as RandomCircleRevealTransitionEffect).CloudImage = new ImageBrush(GetRandomTexture());
        }


        public EffectManager()
        {
            _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _r = new Random();
            _cnt = 0;
            InitilazeEffects();
            RandomizeParameters();
        }

        public TransitionEffect GetEffect()
        {
            ++_cnt;
            if (_cnt > _Effects.Length)
            {
                RandomizeParameters();
                _cnt = 0;
            }
            int eff = _r.Next(0, _Effects.Length - 1);
            return _Effects[eff];
        }
    }
}
