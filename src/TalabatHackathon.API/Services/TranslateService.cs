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
    /// Translates the specified text from the source language to the target language asynchronously.
    /// </summary>
    /// <param name="sourceLanguage">The language code of the source language (e.g., "en" for English).</param>
    /// <param name="targetLanguage">The language code of the target language (e.g., "es" for Spanish).</param>
    /// <param name="text">The text to be translated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the translated text.</returns>
    /// <remarks>
    /// This method constructs a translation request using the provided source and target language codes along with the text to be translated.
    /// It then sends this request to a translation service client and awaits the response.
    /// Upon receiving the response, it extracts and returns the translated text.
    /// This method is designed to be used in an asynchronous programming model, allowing for non-blocking calls.
    /// </remarks>
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
            TargetLanguageCode = targetLanguage,
        };

        var response = await _translateClient.TranslateTextAsync(request);

        return response.TranslatedText;
    }
}
