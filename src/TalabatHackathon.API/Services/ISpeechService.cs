namespace TalabatHackathon.API.Services;

public interface ISpeechService
{
    Task<byte[]> GetSpeech(string language, string text);
}