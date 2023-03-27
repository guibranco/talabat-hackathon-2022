// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="SpeechResponseModel.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace TalabatHackathon.API.Models
{
    /// <summary>
    /// Class SpeechResponseModel.
    /// </summary>
    public class SpeechResponseModel
    {
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>The language.</value>
        public string Language { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }
    }
}
