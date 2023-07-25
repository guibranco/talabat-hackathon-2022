// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="MemoryCacheSpeechService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Concurrent;

namespace TalabatHackathon.API.Services;

/// <summary>
/// Class MemoryCacheSpeechService.
/// Implements the <see cref="TalabatHackathon.API.Services.ISpeechService" />
/// </summary>
/// <seealso cref="TalabatHackathon.API.Services.ISpeechService" />
public class MemoryCacheSpeechService : ISpeechService
{
    /// <summary>
    /// The speech service
    /// </summary>
    private readonly ISpeechService _speechService;

    /// <summary>
    /// The cache repository
    /// </summary>
    private readonly ConcurrentDictionary<string, byte[]> _cacheRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="MemoryCacheSpeechService" /> class.
    /// </summary>
    /// <param name="speechService">The speech service.</param>
    public MemoryCacheSpeechService(ISpeechService speechService)
    {
        _speechService = speechService;
        _cacheRepository = new();
    }

    /// <summary>
    /// Gets the speech.
    /// </summary>
    /// <param name="language">The language.</param>
    /// <param name="text">The text.</param>
    /// <returns>Task&lt;System.Byte[]&gt;.</returns>
    public Task<byte[]> GetSpeech(string language, string text)
    {
        var textMd5 = text.GetMd5Hash();
        var key = $"s_{language}_{textMd5}";
        var value = _cacheRepository.GetOrAdd(
            key,
            _ => _speechService.GetSpeech(language, text).Result
        );

        return Task.FromResult(value);
    }
}
