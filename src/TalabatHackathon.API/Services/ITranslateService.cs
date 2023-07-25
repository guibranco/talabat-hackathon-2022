// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="ITranslateService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace TalabatHackathon.API.Services;

/// <summary>
/// Interface ITranslateService
/// </summary>
public interface ITranslateService
{
    /// <summary>
    /// Translates the asynchronous.
    /// </summary>
    /// <param name="sourceLanguage">The source language.</param>
    /// <param name="targetLanguage">The target language.</param>
    /// <param name="text">The text.</param>
    /// <returns>Task&lt;System.String&gt;.</returns>
    Task<string> TranslateAsync(string sourceLanguage, string targetLanguage, string text);
}
