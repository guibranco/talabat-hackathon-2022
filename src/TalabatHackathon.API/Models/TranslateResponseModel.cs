// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="TranslateResponseModel.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace TalabatHackathon.API.Models;

/// <summary>
/// Class TranslateResponseModel.
/// </summary>
public class TranslateResponseModel
{
    /// <summary>
    /// Gets or sets the language.
    /// </summary>
    /// <value>The language.</value>
    public string Language { get; set; }

    /// <summary>
    /// Gets or sets the texts.
    /// </summary>
    /// <value>The texts.</value>
    public string[] Texts { get; set; }
}
