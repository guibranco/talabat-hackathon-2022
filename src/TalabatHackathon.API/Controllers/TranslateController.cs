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

using Microsoft.AspNetCore.Mvc;
using TalabatHackathon.API.Models;
using TalabatHackathon.API.Services;

namespace TalabatHackathon.API.Controllers;

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
    /// Initializes a new instance of the <see cref="TranslateController" /> class.
    /// </summary>
    /// <param name="translateService">The translate service.</param>
    public TranslateController(ITranslateService translateService) =>
        _translateService = translateService;

    /// <summary>
    /// Translates a list of texts from a source language to a destination language asynchronously.
    /// </summary>
    /// <param name="model">The request model containing the source language, destination language, and texts to be translated.</param>
    /// <returns>An <see cref="IActionResult"/> containing the translation results or a bad request response if the input is invalid.</returns>
    /// <remarks>
    /// This method first validates the source and destination languages against a predefined list of supported languages.
    /// It checks that both languages are valid and that they are not the same. If any validation fails, it adds appropriate errors to the model state.
    /// If the model state is valid, it proceeds to translate each text in the provided list using an external translation service.
    /// The translations are collected and returned in a response model that includes the destination language and the translated texts.
    /// This method is decorated with HTTP POST attributes and produces a response of type <see cref="TranslateResponseModel"/> upon successful translation.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="model"/> is null.</exception>
    [HttpPost]
    [ProducesResponseType(typeof(TranslateResponseModel), 200)]
    public async Task<IActionResult> TranslateAsync([FromBody] TranslateRequestModel model)
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
                Texts = results.ToArray(),
            }
        );
    }
}
