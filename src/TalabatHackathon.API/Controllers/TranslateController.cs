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
            if (Constants.TranslateLanguages.All(x => x.Value != model.SourceLanguage))
            {
                ModelState.AddModelError(nameof(model.SourceLanguage), "Invalid source language");
            }

            if (Constants.TranslateLanguages.All(x => x.Value != model.DestinationLanguage))
            {
                ModelState.AddModelError(nameof(model.DestinationLanguage), "Invalid destination language");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = new Dictionary<string, string>();

            foreach (var text in model.Texts)
            {
                var translation =
                    await _translateService.TranslateAsync(model.SourceLanguage, model.DestinationLanguage, text.Value);
                results.Add(text.Key, translation);
            }

            return Ok(new TranslateResponseModel
            {
                Language = model.DestinationLanguage,
                Texts = results
            });
        }
    }
}
