namespace TalabatHackathon.API.Services;

public interface IAudioFileService
{
    bool Exists(string key);
    void Store(string key, byte[] bytes);
    byte[] Retrieve(string key);
}
