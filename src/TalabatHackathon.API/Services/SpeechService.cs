// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="SpeechService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;

namespace TalabatHackathon.API.Services;

/// <summary>
/// Class SpeechService.
/// Implements the <see cref="TalabatHackathon.API.Services.ISpeechService" />
/// </summary>
/// <seealso cref="TalabatHackathon.API.Services.ISpeechService" />
public class SpeechService : ISpeechService
{
    /// <summary>
    /// The polly client
    /// </summary>
    private readonly AmazonPollyClient _pollyClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpeechService"/> class.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public SpeechService(IConfiguration configuration)
    {
        _pollyClient = new(
            configuration.GetValue<string>("AWS_ACCESS_KEY_ID"),
            configuration.GetValue<string>("AWS_SECRET_ACCESS_KEY"),
            RegionEndpoint.USEast1
        );
    }

    /// <summary>
    /// Gets the speech.
    /// </summary>
    /// <param name="language">The language.</param>
    /// <param name="text">The text.</param>
    /// <returns>Task&lt;System.Byte[]&gt;.</returns>
    public async Task<byte[]> GetSpeech(string language, string text)
    {
        var request = new SynthesizeSpeechRequest();
        request.Text = text;
        request.LanguageCode = language;
        request.OutputFormat = OutputFormat.Mp3;
        request.VoiceId = VoiceId.Amy;

        var response = await _pollyClient.SynthesizeSpeechAsync(request);

        return response.AudioStream.ReadFully();
    }
}
