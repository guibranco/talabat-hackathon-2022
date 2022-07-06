using Microsoft.AspNetCore.Mvc;
using TalabatHackathon.API.Models;

namespace TalabatHackathon.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/settings")]
    [ApiVersion("1.0")]
    public class SettingsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(SettingsResponseModel), 200)]
        public IActionResult GetSettings()
        {
            var response = new SettingsResponseModel
            {
                TranslateIsoCodes = Constants.TranslateLanguages.Select(l => l.Value).ToArray(),
                TranslateIsoPairs = Constants.TranslateLanguages
            };

            return Ok(response);
        }
    }
}
