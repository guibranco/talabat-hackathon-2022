// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="AudioFileService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace TalabatHackathon.API.Services;

/// <summary>
/// Class AudioFileService.
/// Implements the <see cref="TalabatHackathon.API.Services.IAudioFileService" />
/// </summary>
/// <seealso cref="TalabatHackathon.API.Services.IAudioFileService" />
public class AudioFileService : IAudioFileService
{
    /// <summary>
    /// The cache path
    /// </summary>
    private const string _cachePath = "cached_audios";

    /// <summary>
    /// Initializes a new instance of the <see cref="AudioFileService" /> class.
    /// </summary>
    public AudioFileService()
    {
        if (!Directory.Exists(_cachePath))
            Directory.CreateDirectory(_cachePath);
    }

    /// <summary>
    /// Existses the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    public bool Exists(string key)
    {
        return File.Exists(Path.Combine(_cachePath, key));
    }

    /// <summary>
    /// Stores the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="bytes">The bytes.</param>
    public void Store(string key, byte[] bytes)
    {
        if (key.StartsWith("s_") && key.EndsWith(".mp3"))
        {
            File.WriteAllBytes(Path.Combine(_cachePath, key), bytes);
        }
    }

    /// <summary>
    /// Retrieves the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>System.Byte[].</returns>
    public byte[] Retrieve(string key)
    {
        if (key.StartsWith("s_") && key.EndsWith(".mp3"))
        {
            return File.ReadAllBytes(Path.Combine(_cachePath, key));
        }

        return Array.Empty<byte>();
    }
}
