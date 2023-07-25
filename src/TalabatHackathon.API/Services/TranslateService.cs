// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="TranslateService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using Amazon;
using Amazon.Translate;
using Amazon.Translate.Model;

namespace TalabatHackathon.API.Services;

/// <summary>
/// Class TranslateService.
/// Implements the <see cref="TalabatHackathon.API.Services.ITranslateService" />
/// </summary>
/// <seealso cref="TalabatHackathon.API.Services.ITranslateService" />
public class TranslateService : ITranslateService
{
    /// <summary>
    /// The translate client
    /// </summary>
    private readonly AmazonTranslateClient _translateClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="TranslateService" /> class.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public TranslateService(IConfiguration configuration)
    {
        _translateClient = new(
            configuration.GetValue<string>("AWS_ACCESS_KEY_ID"),
            configuration.GetValue<string>("AWS_SECRET_ACCESS_KEY"),
            RegionEndpoint.USEast1
        );
    }

    /// <summary>
    /// Translate as an asynchronous operation.
    /// </summary>
    /// <param name="sourceLanguage">The source language.</param>
    /// <param name="targetLanguage">The target language.</param>
    /// <param name="text">The text.</param>
    /// <returns>A Task&lt;System.String&gt; representing the asynchronous operation.</returns>
    public async Task<string> TranslateAsync(
        string sourceLanguage,
        string targetLanguage,
        string text
    )
    {
        var request = new TranslateTextRequest
        {
            Text = text,
            SourceLanguageCode = sourceLanguage,
            TargetLanguageCode = targetLanguage
        };

        var response = await _translateClient.TranslateTextAsync(request);

        return response.TranslatedText;
    }
}
