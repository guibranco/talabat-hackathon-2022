namespace TalabatHackathon.API.Services;

public interface ITranslateService
{
    Task<string> TranslateAsync(string sourceLanguage, string targetLanguage, string text);
}