// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="SpeechController.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using TalabatHackathon.API.Models;
using TalabatHackathon.API.Services;

namespace TalabatHackathon.API.Controllers;

/// <summary>
/// Class SpeechController.
/// Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("api/v{version:apiVersion}/speech")]
[ApiVersion("1.0")]
public class SpeechController : ControllerBase
{
    /// <summary>
    /// The speech service
    /// </summary>
    private readonly ISpeechService _speechService;

    /// <summary>
    /// The audio file service
    /// </summary>
    private readonly IAudioFileService _audioFileService;

    /// <summary>
    /// The host URL
    /// </summary>
    private readonly string _hostUrl;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpeechController" /> class.
    /// </summary>
    /// <param name="speechService">The speech service.</param>
    /// <param name="audioFileService">The audio file service.</param>
    /// <param name="configuration">The configuration.</param>
    public SpeechController(
        ISpeechService speechService,
        IAudioFileService audioFileService,
        IConfiguration configuration
    )
    {
        _speechService = speechService;
        _audioFileService = audioFileService;
        _hostUrl = configuration.GetValue<string>("hostUrl") ?? "https://localhost:7170";
    }

    /// <summary>
    /// Speeches the specified model.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(SpeechResponseModel), 200)]
    public async Task<IActionResult> Speech(
        [FromBody] SpeechRequestModel model,
        CancellationToken cancellationToken
    )
    {
        var hash = model.Text.GetMd5Hash();
        var language = Constants.TranslateLanguages.Values.Any(model.Language)
            ? model.Language
            : "en";

        var key = $"s_{language}_{hash}.mp3";

        var result = new SpeechResponseModel
        {
            Language = language,
            Text = model.Text,
            Path = $"{_hostUrl}/api/v1/audio/{key}"
        };

        var exists = _audioFileService.Exists(key);

        HttpContext.Response.Headers.TryAdd("x-cache", exists ? "Hit" : "Miss");

        if (exists)
        {
            return Ok(result);
        }

        var audioResult = await _speechService.GetSpeech(language, model.Text);
        _audioFileService.Store(key, audioResult);

        return Ok(result);
    }
}
