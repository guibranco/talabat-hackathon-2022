// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="IAudioFileService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace TalabatHackathon.API.Services;

/// <summary>
/// Interface IAudioFileService
/// </summary>
public interface IAudioFileService
{
    /// <summary>
    /// Existses the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    bool Exists(string key);

    /// <summary>
    /// Stores the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="bytes">The bytes.</param>
    void Store(string key, byte[] bytes);

    /// <summary>
    /// Retrieves the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>System.Byte[].</returns>
    byte[] Retrieve(string key);
}
