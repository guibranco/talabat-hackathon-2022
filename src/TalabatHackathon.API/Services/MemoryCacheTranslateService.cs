// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="MemoryCacheTranslateService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Concurrent;

namespace TalabatHackathon.API.Services;

/// <summary>
/// Class MemoryCacheTranslateService.
/// Implements the <see cref="TalabatHackathon.API.Services.ITranslateService" />
/// </summary>
/// <seealso cref="TalabatHackathon.API.Services.ITranslateService" />
public class MemoryCacheTranslateService : ITranslateService
{
    /// <summary>
    /// The translate service
    /// </summary>
    private readonly ITranslateService _translateService;

    /// <summary>
    /// The cache repository
    /// </summary>
    private readonly ConcurrentDictionary<string, string> _cacheRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="MemoryCacheTranslateService" /> class.
    /// </summary>
    /// <param name="translateService">The translate service.</param>
    public MemoryCacheTranslateService(ITranslateService translateService)
    {
        _translateService = translateService;
        _cacheRepository = new();
    }

    /// <summary>
    /// Translates the asynchronous.
    /// </summary>
    /// <param name="sourceLanguage">The source language.</param>
    /// <param name="targetLanguage">The target language.</param>
    /// <param name="text">The text.</param>
    /// <returns>Task&lt;System.String&gt;.</returns>
    public Task<string> TranslateAsync(string sourceLanguage, string targetLanguage, string text)
    {
        var textMd5 = text.GetMd5Hash();
        var key = $"t_{sourceLanguage}_{targetLanguage}_{textMd5}";
        var value = _cacheRepository.GetOrAdd(
            key,
            (_) => _translateService.TranslateAsync(sourceLanguage, targetLanguage, text).Result
        );

        return Task.FromResult(value);
    }
}
