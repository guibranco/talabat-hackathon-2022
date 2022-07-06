namespace TalabatHackathon.API.Services;

public class AudioFileService : IAudioFileService
{
    public bool Exists(string key)
    {
        return File.Exists(key);
    }

    public void Store(string key, byte[] bytes)
    {
        File.WriteAllBytes(key, bytes);
    }
}