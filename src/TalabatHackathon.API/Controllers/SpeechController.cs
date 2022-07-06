using Microsoft.AspNetCore.Mvc;
using TalabatHackathon.API.Models;
using TalabatHackathon.API.Services;

namespace TalabatHackathon.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/speech")]
    [ApiVersion("1.0")]
    public class SpeechController : ControllerBase
    {
        private readonly ISpeechService _speechService;
        private readonly IAudioFileService _audioFileService;

        public SpeechController(ISpeechService speechService, IAudioFileService audioFileService)
        {
            _speechService = speechService;
            _audioFileService = audioFileService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SpeechResponseModel), 200)]
        public async Task<IActionResult> Speech([FromBody] SpeechRequestModel model, CancellationToken cancellationToken)
        {
            var key = $"s_{model.Language}_{model.Text.GetMd5Hash()}.mp3";

            var result = new SpeechResponseModel();
            result.Language = model.Language;
            result.Text = model.Text;
            result.Path = $"https://talabat-hackathon.herokuapp.com/api/v1/audio/{key}";

            if (!_audioFileService.Exists(key))
            {
                var audioResult = await _speechService.GetSpeech(model.Language, model.Text);
                _audioFileService.Store(key, audioResult);
            }

            return Ok(result);
        }
    }
}
