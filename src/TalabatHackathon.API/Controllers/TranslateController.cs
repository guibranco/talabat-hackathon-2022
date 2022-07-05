namespace TalabatHackathon.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TalabatHackathon.API.Models;

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TranslateController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(TranslateResponseModel), 200)]
        public IActionResult Translante([FromBody] TranslateRequestModel model, CancellationToken token)
        {
            return Ok(new TranslateResponseModel
            {
                Language = model.DestinationLanguage,
                Text = model.Text
            });
        }
    }
}
