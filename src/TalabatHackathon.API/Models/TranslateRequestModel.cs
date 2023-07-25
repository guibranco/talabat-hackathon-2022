// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="TranslateRequestModel.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace TalabatHackathon.API.Models;

/// <summary>
/// Class TranslateRequestModel.
/// </summary>
public class TranslateRequestModel
{
    /// <summary>
    /// Gets or sets the source language.
    /// </summary>
    /// <value>The source language.</value>
    [Required]
    public string SourceLanguage { get; set; }

    /// <summary>
    /// Gets or sets the destination language.
    /// </summary>
    /// <value>The destination language.</value>
    [Required]
    public string DestinationLanguage { get; set; }

    /// <summary>
    /// Gets or sets the texts.
    /// </summary>
    /// <value>The texts.</value>
    [Required]
    public string[] Texts { get; set; }
}
