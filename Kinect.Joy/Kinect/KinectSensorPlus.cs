using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinect.Joy
{
    using System.Windows;
    using System.Windows.Shapes;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Kinect;
    using Microsoft.Samples.Kinect.SwipeGestureRecognizer;
    using Kinect.FingerTracking;

    public class KinectSensorPlus
    {

        public KinectSensor Sensor { get; private set; }
        private byte[] colorPixels;
        private DepthImagePixel[] depthPixels;
        private byte[] depthColor;
        public WriteableBitmap ColorBitmap { get; private set; }
        public WriteableBitmap DepthBitmap { get; private set; }


        private int DepthFrameWidth;
        private int DepthFrameHeight;
        private bool skeletonReadyFlag = false;
        private bool drawFlag = false;
        private PointSkeleton3D leftHand;
        private PointSkeleton3D rightHand;
        private const int rectWidth = 120;
        private const int rectHeight = 120;
        private PointDepth3D[] rectDepth3D;
        private FingerDetection detector;
        public FingerIdentification Fingers { get; set; }
        private static int timeStamp = 0;   //记录帧号，每3000帧循环一次，100秒

        public ViewEnum CurrViewType { get; set; }
        public Recognizer activeRecognizer;                     //SwipeLeft,SwipRight Recognizer
        public delegate void SkeletonFrameHandler(Skeleton sk,FingerIdentification Fingers);      //delegate declare for Skeleton Drawing in CameraView.xmal
        public SkeletonFrameHandler DrawSkeletonAndFingers;
        public delegate void PlayPianoHandler(FingerIdentification Fingers);
        public PlayPianoHandler PlayPiano;

        public KinectSensorPlus(KinectSensor sensor)
        {
            try
            {
                if (null != sensor)
                {
                    this.Sensor = sensor;
                    this.colorPixels = new byte[this.Sensor.ColorStream.FramePixelDataLength];
                    this.depthPixels = new DepthImagePixel[this.Sensor.DepthStream.FramePixelDataLength];
                    this.depthColor = new byte[this.Sensor.DepthStream.FramePixelDataLength * sizeof(int)];
                    this.ColorBitmap = new WriteableBitmap(this.Sensor.ColorStream.FrameWidth, this.Sensor.ColorStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);
                    this.DepthBitmap = new WriteableBitmap(this.Sensor.DepthStream.FrameWidth, this.Sensor.DepthStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);

                    //Enable All Stream
                    if (!this.Sensor.ColorStream.IsEnabled)
                        this.Sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                    if (!this.Sensor.DepthStream.IsEnabled)
                        this.Sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    if(!this.Sensor.SkeletonStream.IsEnabled)
                        this.Sensor.SkeletonStream.Enable();

                    this.DepthFrameWidth = this.Sensor.DepthStream.FrameWidth;
                    this.DepthFrameHeight = this.Sensor.DepthStream.FrameHeight;
                    
                    //Register frame ready event
                    this.Sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(Sensor_SkeletonFrameReady);
                    this.Sensor.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(Sensor_ColorFrameReady);
                    this.Sensor.DepthFrameReady += new EventHandler<DepthImageFrameReadyEventArgs>(Sensor_DepthFrameReady);

                    //Initialization for finger tracking
                    this.rectDepth3D = new PointDepth3D[rectWidth * rectHeight];
                    this.detector = new FingerDetection(this.Sensor);
                    this.Fingers = new FingerIdentification(this.Sensor);
                    this.rectDepth3D = new PointDepth3D[rectWidth * rectHeight];
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Release frame ready event
        /// </summary>
        public void ReleaseFrameReady()
        {
            this.Sensor.SkeletonFrameReady -= Sensor_SkeletonFrameReady;
            this.Sensor.DepthFrameReady -= Sensor_DepthFrameReady;
            this.Sensor.ColorFrameReady -= Sensor_ColorFrameReady;
        }

        void Sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame != null)
                {
                    colorFrame.CopyPixelDataTo(this.colorPixels);
                    this.ColorBitmap.WritePixels(
                        new Int32Rect(0, 0, this.ColorBitmap.PixelWidth, this.ColorBitmap.PixelHeight),
                        this.colorPixels,
                        this.ColorBitmap.PixelWidth * sizeof(int),
                        0);
                }
            }
        }
        
        void Sensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            if (!skeletonReadyFlag || CurrViewType != ViewEnum.CameraView)     //return if no person is detected
                return;
            using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
            {
                if (depthFrame != null)
                {
                    depthFrame.CopyDepthImagePixelDataTo(this.depthPixels);

                    CoordinateMapperPlus mapper = new CoordinateMapperPlus(this.Sensor);
                    PointDepth3D leftDepth3D = mapper.MapSkeletonPointToDepthPoint(leftHand, this.Sensor.DepthStream.Format);
                    PointDepth3D rightDepth3D = mapper.MapSkeletonPointToDepthPoint(rightHand, this.Sensor.DepthStream.Format);

                    int index = rightDepth3D.Y * DepthFrameWidth + rightDepth3D.X;
                    if (index < 0 || index > this.depthPixels.Length)
                        return;
                    short currDepth = depthPixels[index].Depth;

                    int indexColor = 0;
                    int rectSize = 0;
                    for (int i = 0; i < this.DepthFrameWidth; i++)
                    {
                        for (int j = 0; j < this.DepthFrameHeight; j++)
                        {
                            indexColor = (j * this.DepthFrameWidth + i) * 4;
                            if (KinectUtil.isInTrackRegion(i, j, rightDepth3D.X, rightDepth3D.Y))
                            {
                                int indexDepthPixels = j * this.DepthFrameWidth + i;
                                rectDepth3D[rectSize++] = new PointDepth3D(i, j, depthPixels[indexDepthPixels].Depth);

                            }
                        }
                    }
                    if (rectSize == rectWidth * rectHeight)
                    {
                        detector.RightHand = new Hand(rectDepth3D, rightDepth3D, rectWidth, rectHeight);
                        detector.DetectAndSmooth(timeStamp);

                        Fingers.Identify3(this.Sketelon3DFingerTips, timeStamp);
                        timeStamp = (++timeStamp) % KinectUtil.LOOP_TIMES;
                    }

                    this.DepthBitmap.WritePixels(
                         new Int32Rect(0, 0, this.DepthBitmap.PixelWidth, this.DepthBitmap.PixelHeight),
                         this.depthColor,
                         this.DepthBitmap.PixelWidth * sizeof(int),
                         0);

                }
            }
        }

        void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
                int personCount = 0;
                foreach (Skeleton sk in skeletons)
                {
                    if (sk.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        //get left and right hand for finding Finger Rect Region
                        leftHand = new PointSkeleton3D(sk.Joints[JointType.HandLeft].Position);
                        rightHand = new PointSkeleton3D(sk.Joints[JointType.HandRight].Position);
                        if (ViewEnum.CameraView == CurrViewType && drawFlag)     //Draw Skeleton every frame in CameraView.xmal.cs
                            DrawSkeletonAndFingers(sk, this.Fingers);
                       
                        personCount++;
                    }
                }
                if (ViewEnum.FullView == CurrViewType)              //Recognize Swip left or right every frame in FullView.xmal.cs
                    this.activeRecognizer.Recognize(sender, skeletonFrame, skeletons);
                skeletonReadyFlag = (personCount == 0 ? false : true);

                //set draw skeleton flag true
                if (Fingers.FingerTrackedCount == 2 && Fingers[FingerType.ThumbRight].TrackingState == FingerTrackingState.Tracked && Fingers[FingerType.IndexRight].TrackingState == FingerTrackingState.Tracked)
                {
                    drawFlag = true;
                }
                //cancle draw skeleton flag
                if (Fingers.FingerTrackedCount == 1 && Fingers[FingerType.ThumbRight].TrackingState == FingerTrackingState.Tracked)
                {
                    drawFlag = false;
                    DrawSkeletonAndFingers(null, null);
                }
                if (CurrViewType == ViewEnum.CameraView && drawFlag)
                    PlayPiano(this.Fingers);
            }
        }

        #region Property
        public List<PointSkeleton3D> Sketelon3DFingerTips
        {
            get
            {
                return this.detector.Skeleton3DFingerTips;
            }
        }
        #endregion
    }
}
