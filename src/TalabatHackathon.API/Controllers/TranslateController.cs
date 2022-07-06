using TalabatHackathon.API.Services;

namespace TalabatHackathon.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TalabatHackathon.API.Models;

    [ApiController]
    [Route("api/v{version:apiVersion}/translate")]
    [ApiVersion("1.0")]
    public class TranslateController : ControllerBase
    {
        private readonly ITranslateService _translateService;

        public TranslateController(ITranslateService translateService) => _translateService = translateService;

        [HttpPost]
        [ProducesResponseType(typeof(TranslateResponseModel), 200)]
        public async Task<IActionResult> TranslanteAsync([FromBody] TranslateRequestModel model)
        {

            var result =
                await _translateService.TranslateAsync(model.SourceLanguage, model.DestinationLanguage, model.Text);

            return Ok(new TranslateResponseModel
            {
                Language = model.DestinationLanguage,
                Text = result
            });
        }
    }
}
