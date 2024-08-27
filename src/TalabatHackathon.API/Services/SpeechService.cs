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
    /// Asynchronously generates speech from the provided text in the specified language.
    /// </summary>
    /// <param name="language">The language code for the speech synthesis (e.g., "en-US").</param>
    /// <param name="text">The text to be converted into speech.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a byte array representing the audio stream of the synthesized speech.</returns>
    /// <remarks>
    /// This method creates a speech synthesis request using the Amazon Polly service, specifying the text to be spoken, the desired language, the output format (MP3), and the voice to be used (in this case, "Amy").
    /// It then sends the request asynchronously and waits for the response. Once the audio stream is received, it reads the stream fully into a byte array, which can be used for playback or storage.
    /// This method relies on the Amazon Polly client (_pollyClient) to perform the synthesis operation.
    /// </remarks>
    public async Task<byte[]> GetSpeech(string language, string text)
    {
        var request = new SynthesizeSpeechRequest
        {
            Text = text,
            LanguageCode = language,
            OutputFormat = OutputFormat.Mp3,
            VoiceId = VoiceId.Amy,
        };

        var response = await _pollyClient.SynthesizeSpeechAsync(request);

        return response.AudioStream.ReadFully();
    }
}
