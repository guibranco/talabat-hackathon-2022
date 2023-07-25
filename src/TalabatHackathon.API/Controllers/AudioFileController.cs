// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="AudioFileController.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using TalabatHackathon.API.Services;

namespace TalabatHackathon.API.Controllers;

/// <summary>
/// Class AudioFileController.
/// Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("api/v{version:apiVersion}/audio")]
[ApiVersion("1.0")]
public class AudioFileController : ControllerBase
{
    /// <summary>
    /// The audio file service
    /// </summary>
    private readonly IAudioFileService _audioFileService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AudioFileController"/> class.
    /// </summary>
    /// <param name="audioFileService">The audio file service.</param>
    public AudioFileController(IAudioFileService audioFileService) =>
        _audioFileService = audioFileService;

    /// <summary>
    /// Gets the audio.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>IActionResult.</returns>
    [HttpGet("{path}")]
    public IActionResult GetAudio([FromRoute] string path)
    {
        if (path.StartsWith("s_") && path.EndsWith(".mp3") && _audioFileService.Exists(path))
        {
            return File(_audioFileService.Retrieve(path), "audio/mp3");
        }

        return NotFound();
    }
}
