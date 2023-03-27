using Amazon;
using Amazon.Translate;
using Amazon.Translate.Model;

namespace TalabatHackathon.API.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly AmazonTranslateClient _translateClient;

        public TranslateService(IConfiguration configuration)
        {
            _translateClient = new(
                configuration.GetValue<string>("AWS_ACCESS_KEY_ID"),
                configuration.GetValue<string>("AWS_SECRET_ACCESS_KEY"),
                RegionEndpoint.USEast1
            );
        }

        public async Task<string> TranslateAsync(
            string sourceLanguage,
            string targetLanguage,
            string text
        )
        {
            var request = new TranslateTextRequest
            {
                Text = text,
                SourceLanguageCode = sourceLanguage,
                TargetLanguageCode = targetLanguage
            };

            var response = await _translateClient.TranslateTextAsync(request);

            return response.TranslatedText;
        }
    }
}
