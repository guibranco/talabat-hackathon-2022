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

        public SpeechController(ISpeechService speechService) => _speechService = speechService;

        [HttpPost]
        public async Task<IActionResult> Speech([FromBody] SpeechRequestModel model, CancellationToken cancellationToken)
        {
            var result = await _speechService.GetSpeech(model.Language, model.Text);
            return File(result, "audio/mp3");
        }
    }
}
