using System.Collections.Concurrent;
using System.Globalization;
using System.Security.Authentication;
using System.Text.Unicode;

namespace TalabatHackathon.API.Services
{
    public class MemoryCacheTranslateService : ITranslateService
    {
        private readonly ITranslateService _translateService;

        private readonly ConcurrentDictionary<string, string> _cacheRepository;

        public MemoryCacheTranslateService(ITranslateService translateService)
        {
            _translateService = translateService;
            _cacheRepository = new();
        }

        public Task<string> TranslateAsync(
            string sourceLanguage,
            string targetLanguage,
            string text
        )
        {
            var textMd5 = text.GetMd5Hash();
            var key = $"t_{sourceLanguage}_{targetLanguage}_{textMd5}";
            var value = _cacheRepository.GetOrAdd(
                key,
                (_) => _translateService.TranslateAsync(sourceLanguage, targetLanguage, text).Result
            );

            return Task.FromResult(value);
        }
    }
}
