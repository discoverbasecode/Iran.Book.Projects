using NAudio.Wave;

namespace Framework.Application.FileUtils;

public static class AudioUtils
{

    public static void SaveAudio(string filePath, byte[] audioData)
    {
        File.WriteAllBytes(filePath, audioData);
    }

    public static byte[] LoadAudio(string filePath)
    {
        return File.ReadAllBytes(filePath);
    }

    public static void PlayAudio(string filePath)
    {
        using var audioFileReader = new AudioFileReader(filePath);
        using var outputDevice = new WaveOutEvent();
        outputDevice.Init(audioFileReader);
        outputDevice.Play();
        while (outputDevice.PlaybackState == PlaybackState.Playing)
        {
            System.Threading.Thread.Sleep(100);
        }
    }

}
