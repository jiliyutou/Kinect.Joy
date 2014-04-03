using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Kinect.Joy
{
    using Microsoft.Kinect;
    using Microsoft.Speech.AudioFormat;
    using Microsoft.Speech.Recognition;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
        Justification = "In a full-fledged application, the SpeechRecognitionEngine object should be properly disposed. For the sake of simplicity, we're omitting that code in this sample.")]
    public class SpeechRecognizer
    {
        private SpeechRecognitionEngine speechEngine;
        private KinectSensor sensor;

        public SpeechRecognizer(KinectSensor sensor)
        {
            this.sensor = sensor;
            RecognizerInfo ri = GetKinectRecognizer();
            this.speechEngine = new SpeechRecognitionEngine(ri);
            // Create a grammar from grammar definition XML file.
            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(Properties.Resources.SpeechGrammar)))
            {
                var g = new Grammar(memoryStream);
                speechEngine.LoadGrammar(g);
            }

            speechEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);
            speechEngine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(SpeechRejected);

            speechEngine.SetInputToAudioStream(
                    sensor.AudioSource.Start(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            speechEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        /// <summary>
        /// Gets the metadata for the speech recognizer (acoustic model) most suitable to
        /// process audio from Kinect device.
        /// </summary>
        /// <returns>
        /// RecognizerInfo if found, <code>null</code> otherwise.
        /// </returns>
        private static RecognizerInfo GetKinectRecognizer()
        {
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) && "en-US".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }


        /// <summary>
        /// Handler for recognized speech events.
        /// </summary>
        /// <param name="sender">object sending the event.</param>
        /// <param name="e">event arguments.</param>
        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Speech utterance confidence below which we treat speech as if it hadn't been heard
            const double ConfidenceThreshold = 0.3;

            if (e.Result.Confidence >= ConfidenceThreshold)
            {
                switch (e.Result.Semantics.Value.ToString())
                {
                    case "SHARE":
                        System.Windows.MessageBox.Show("share");
                        break;

                    case "BACK":
                        System.Windows.MessageBox.Show("back");
                        break;

                    case "PHOTO":
                        System.Windows.MessageBox.Show("photo");
                        break;

                }
            }
        }

        void SpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
        }

    }
}
