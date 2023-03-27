// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="SettingsResponseModel.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Immutable;

namespace TalabatHackathon.API.Models;

/// <summary>
/// Class SettingsResponseModel.
/// </summary>
public class SettingsResponseModel
{
    /// <summary>
    /// Gets or sets the translate iso codes.
    /// </summary>
    /// <value>The translate iso codes.</value>
    public string[] TranslateIsoCodes { get; set; }

    /// <summary>
    /// Gets or sets the translate iso pairs.
    /// </summary>
    /// <value>The translate iso pairs.</value>
    public ImmutableDictionary<string, string> TranslateIsoPairs { get; set; }
}
