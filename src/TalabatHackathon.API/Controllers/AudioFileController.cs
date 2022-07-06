using Microsoft.AspNetCore.Mvc;
using TalabatHackathon.API.Services;

namespace TalabatHackathon.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/audio")]
    [ApiVersion("1.0")]
    public class AudioFileController : ControllerBase
    {
        private readonly IAudioFileService _audioFileService;

        public AudioFileController(IAudioFileService audioFileService) => _audioFileService = audioFileService; 

        [HttpGet("{path}")]
        public IActionResult GetAudio([FromRoute] string path)
        {
            if (_audioFileService.Exists(path))
            {
                return File(_audioFileService.Retrieve(path), "audio/mp3");
            }

            return NotFound();
        }
    }
}
