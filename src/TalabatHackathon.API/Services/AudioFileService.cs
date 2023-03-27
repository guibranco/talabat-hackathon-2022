namespace TalabatHackathon.API.Services;

public class AudioFileService : IAudioFileService
{
    private const string CachePath = "cached_audios";

    public AudioFileService()
    {
        if (!Directory.Exists(CachePath))
            Directory.CreateDirectory(CachePath);
    }

    public bool Exists(string key)
    {
        return File.Exists(Path.Combine(CachePath, key));
    }

    public void Store(string key, byte[] bytes)
    {
        File.WriteAllBytes(Path.Combine(CachePath, key), bytes);
    }

    public byte[] Retrieve(string key)
    {
        return File.ReadAllBytes(Path.Combine(CachePath, key));
    }
}
