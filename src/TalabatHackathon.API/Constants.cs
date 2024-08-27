﻿// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="Constants.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Immutable;

namespace TalabatHackathon.API;

/// <summary>
/// Class Constants.
/// </summary>
public static class Constants
{
    /// <summary>
    /// The translate languages
    /// </summary>
    public static readonly ImmutableDictionary<string, string> TranslateLanguages = new Dictionary<
        string,
        string
    >
    {
        { "Afrikaans", "af" },
        { "Albanian", "sq" },
        { "Amharic", "am" },
        { "Arabic", "ar" },
        { "Armenian", "hy" },
        { "Azerbaijani", "az" },
        { "Bengali", "bn" },
        { "Bosnian", "bs" },
        { "Bulgarian", "bg" },
        { "Catalan", "ca" },
        { "Chinese (Simplified)", "zh" },
        { "Chinese (Traditional)", "zh-TW" },
        { "Croatian", "hr" },
        { "Czech", "cs" },
        { "Danish", "da" },
        { "Dari", "fa-AF" },
        { "Dutch", "nl" },
        { "English", "en" },
        { "Estonian", "et" },
        { "Farsi (Persian)", "fa" },
        { "Filipino, Tagalog", "tl" },
        { "Finnish", "fi" },
        { "French", "fr" },
        { "French (Canada)", "fr-CA" },
        { "Georgian", "ka" },
        { "German", "de" },
        { "Greek", "el" },
        { "Gujarati", "gu" },
        { "Haitian Creole", "ht" },
        { "Hausa", "ha" },
        { "Hebrew", "he" },
        { "Hindi", "hi" },
        { "Hungarian", "hu" },
        { "Icelandic", "is" },
        { "Indonesian", "id" },
        { "Irish", "ga" },
        { "Italian", "it" },
        { "Japanese", "ja" },
        { "Kannada", "kn" },
        { "Kazakh", "kk" },
        { "Korean", "ko" },
        { "Latvian", "lv" },
        { "Lithuanian", "lt" },
        { "Macedonian", "mk" },
        { "Malay", "ms" },
        { "Malayalam", "ml" },
        { "Maltese", "mt" },
        { "Marathi", "mr" },
        { "Mongolian", "mn" },
        { "Norwegian", "no" },
        { "Pashto", "ps" },
        { "Polish", "pl" },
        { "Portuguese (Brazil)", "pt" },
        { "Portuguese (Portugal)", "pt-PT" },
        { "Punjabi", "pa" },
        { "Romanian", "ro" },
        { "Russian", "ru" },
        { "Serbian", "sr" },
        { "Sinhala", "si" },
        { "Slovak", "sk" },
        { "Slovenian", "sl" },
        { "Somali", "so" },
        { "Spanish", "es" },
        { "Spanish (Mexico)", "es-MX" },
        { "Swahili", "sw" },
        { "Swedish", "sv" },
        { "Tamil", "ta" },
        { "Telugu", "te" },
        { "Thai", "th" },
        { "Turkish", "tr" },
        { "Ukrainian", "uk" },
        { "Urdu", "ur" },
        { "Uzbek", "uz" },
        { "Vietnamese", "vi" },
        { "Welsh", "cy" },
    }.ToImmutableDictionary();
}
