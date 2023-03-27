// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="ISpeechService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace TalabatHackathon.API.Services;

/// <summary>
/// Interface ISpeechService
/// </summary>
public interface ISpeechService
{
    /// <summary>
    /// Gets the speech.
    /// </summary>
    /// <param name="language">The language.</param>
    /// <param name="text">The text.</param>
    /// <returns>Task&lt;System.Byte[]&gt;.</returns>
    Task<byte[]> GetSpeech(string language, string text);
}
