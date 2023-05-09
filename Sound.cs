using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Uss_mäng
{
    public class Sound
    {
        //public async Task Music(string Path)
        //{
        //    await Task.Run(() =>
        //    {
        //        using (AudioFileReader audioFileReader = new AudioFileReader(Path))
        //        using (IWavePlayer waveOutDevice = new WaveOutEvent { DesiredLatency = 200 })
        //        {
        //            waveOutDevice.Init(audioFileReader);
        //            waveOutDevice.Play();
        //            while (waveOutDevice.PlaybackState == PlaybackState.Playing)
        //            {
        //                Thread.Sleep(1000);
        //            }
        //        }
        //    });
        //}
        //public async Task Hrum(string Path)
        //{
        //    await Task.Run(() =>
        //    {
        //        using (AudioFileReader audioFileReader = new AudioFileReader(Path))
        //        using (IWavePlayer waveOutDevice = new WaveOutEvent())
        //        {
        //            waveOutDevice.Init(audioFileReader);
        //            waveOutDevice.Play();
        //            while (waveOutDevice.PlaybackState == PlaybackState.Playing)
        //            {
        //                Thread.Sleep(50);
        //            }
        //        }
        //    });
        //}
    }
}
