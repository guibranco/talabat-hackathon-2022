using System.Collections.Concurrent;

namespace TalabatHackathon.API.Services;

public class MemoryCacheSpeechService : ISpeechService
{
    private readonly ISpeechService _speechService;

    private readonly ConcurrentDictionary<string, byte[]> _cacheRepository;

    public MemoryCacheSpeechService(ISpeechService speechService)
    {
        _speechService = speechService;
        _cacheRepository = new();
    }

    public Task<byte[]> GetSpeech(string language, string text)
    {
        var textMd5 = text.GetMd5Hash();
        var key = $"s_{language}_{textMd5}";
        var value = _cacheRepository.GetOrAdd(key, (_) => _speechService.GetSpeech(language, text).Result);

        return Task.FromResult(value);
    }
}