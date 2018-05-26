using Accord.Video;
using Accord.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Silas.Sight
{
    public class Eye : IEye
    {
        private VideoCaptureDevice _source;
                
        public event EventHandler DataAvailable;
        public int InputIndex { get; private set; }

        public Eye(int inputIndex = 0)
        {
            InputIndex = inputIndex;
            Initialize();
        }

        private void Initialize()
        {
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count < (InputIndex + 1)) throw new Exception($"Video input device {InputIndex} not available.");

            _source = new VideoCaptureDevice(videoDevices[InputIndex].MonikerString);
            _source.NewFrame += _videoSource_NewFrame;
            _source.Start();
        }

        protected virtual void OnDataAvailable(EventArgs e)
        {
            DataAvailable?.Invoke(this, e);
        }

        private void _videoSource_NewFrame(object sender, NewFrameEventArgs e)
        {
            DataAvailable?.Invoke(this, e);
        }

        private void DisposeSource()
        {
            if (_source != null)
            {
                _source.SignalToStop();
                _source.WaitForStop();
            }
        }

        public void Dispose()
        {
            DisposeSource();
        }
    }
}
