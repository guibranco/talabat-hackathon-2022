using Microsoft.AspNetCore.Mvc;
using TalabatHackathon.API.Models;

namespace TalabatHackathon.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/speech")]
    [ApiVersion("1.0")]
    public class SpeechController : ControllerBase
    {
        private const string _fileLocation = "file_example_MP3_700KB.mp3";
        
        [HttpPost]
        public IActionResult Speech(
            [FromBody] SpeechRequestModel model,
            CancellationToken cancellationToken)
        {

            return File(new FileStream(_fileLocation, FileMode.Open, FileAccess.Read), "audio/mp3", true);
        }
    }
}
