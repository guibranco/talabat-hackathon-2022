// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="TranslateController.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
using TalabatHackathon.API.Services;

namespace TalabatHackathon.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TalabatHackathon.API.Models;

    /// <summary>
    /// Class TranslateController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("api/v{version:apiVersion}/translate")]
    [ApiVersion("1.0")]
    public class TranslateController : ControllerBase
    {
        /// <summary>
        /// The translate service
        /// </summary>
        private readonly ITranslateService _translateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslateController"/> class.
        /// </summary>
        /// <param name="translateService">The translate service.</param>
        public TranslateController(ITranslateService translateService) =>
            _translateService = translateService;

        /// <summary>
        /// Translante as an asynchronous operation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task&lt;IActionResult&gt; representing the asynchronous operation.</returns>
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
                ModelState.AddModelError(
                    nameof(model.DestinationLanguage),
                    "Invalid destination language"
                );
            }

            if (model.SourceLanguage == model.DestinationLanguage)
            {
                ModelState.AddModelError(
                    nameof(model.DestinationLanguage),
                    "Destination language cannot be the same as Source language"
                );
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = new List<string>();

            foreach (var text in model.Texts)
            {
                var translation = await _translateService.TranslateAsync(
                    model.SourceLanguage,
                    model.DestinationLanguage,
                    text
                );
                results.Add(translation);
            }

            return Ok(
                new TranslateResponseModel
                {
                    Language = model.DestinationLanguage,
                    Texts = results.ToArray()
                }
            );
        }
    }
}
