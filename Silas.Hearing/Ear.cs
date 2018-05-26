using Accord.Audio;
using Accord.Audio.Formats;
using Accord.DirectSound;
using System;
using System.IO;

namespace Silas.Hearing
{
    public class Ear : IEar
    {
        private IAudioSource _source;
        //private MemoryStream _stream;
        //private float[] _current;
        //private WaveEncoder _encoder;
        //private WaveDecoder _decoder;

        public event EventHandler DataAvailable;

        public Ear()
        {
            Initialize();
        }

        protected virtual void OnDataAvailable(EventArgs e)
        {
            DataAvailable?.Invoke(this, e);
        }

        private void Initialize()
        {
            _source = new AudioCaptureDevice
            {
                SampleRate = 22050,
                Format = SampleFormat.Format128BitComplex,
                DesiredFrameSize = 4096
            };

            _source.AudioSourceError += _source_AudioSourceError;
            _source.NewFrame += _source_NewFrame;

            //_current = new float[_source.DesiredFrameSize];

            //_stream = new MemoryStream();
            //_encoder = new WaveEncoder(_stream);            

            _source.Start();
        }

        private void DisposeSource()
        {
            if (_source != null)
            {
                _source.SignalToStop();
                _source.WaitForStop();
            }

            //Array.Clear(_current, 0, _current.Length);
        }

        private void _source_NewFrame(object sender, NewFrameEventArgs e)
        {
            OnDataAvailable(e);
            //e.Signal.CopyTo(current);
            //_encoder.Encode(e.Signal);
        }

        private void _source_AudioSourceError(object sender, AudioSourceErrorEventArgs e)
        {
            throw new Exception(e.Description);
        }

        public void Dispose()
        {
            DisposeSource();
        }
    }
}
