// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="SettingsController.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using TalabatHackathon.API.Models;

namespace TalabatHackathon.API.Controllers;

/// <summary>
/// Class SettingsController.
/// Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("api/v{version:apiVersion}/settings")]
[ApiVersion("1.0")]
public class SettingsController : ControllerBase
{
    /// <summary>
    /// Retrieves the application settings and returns them in a response model.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the settings response model with translation ISO codes and pairs.</returns>
    /// <remarks>
    /// This method handles HTTP GET requests to retrieve the current application settings.
    /// It constructs a <see cref="SettingsResponseModel"/> that includes:
    /// - An array of translation ISO codes derived from the available languages.
    /// - A dictionary of translation ISO pairs for further processing.
    /// The response is returned with an HTTP status code of 200 (OK) if the operation is successful.
    /// </remarks>
    [HttpGet]
    [ProducesResponseType(typeof(SettingsResponseModel), 200)]
    public IActionResult GetSettings()
    {
        var response = new SettingsResponseModel
        {
            TranslateIsoCodes = Constants.TranslateLanguages.Select(l => l.Value).ToArray(),
            TranslateIsoPairs = Constants.TranslateLanguages,
        };

        return Ok(response);
    }
}
