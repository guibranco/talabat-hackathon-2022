using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;

namespace TalabatHackathon.API.Services
{
    public class SpeechService : ISpeechService
    {
        private readonly AmazonPollyClient _pollyClient;

        public SpeechService(IConfiguration configuration)
        {
            _pollyClient = new(
                configuration.GetValue<string>("AWS_ACCESS_KEY_ID"),
                configuration.GetValue<string>("AWS_SECRET_ACCESS_KEY"),
                RegionEndpoint.USEast1
            );
        }

        public async Task<byte[]> GetSpeech(string language, string text)
        {
            var request = new SynthesizeSpeechRequest();
            request.Text = text;
            request.LanguageCode = language;
            request.OutputFormat = OutputFormat.Mp3;
            request.VoiceId = VoiceId.Amy;

            var response = await _pollyClient.SynthesizeSpeechAsync(request);

            return response.AudioStream.ReadFully();
        }
    }
}
