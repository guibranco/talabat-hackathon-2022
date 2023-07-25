// ***********************************************************************
// Assembly         : TalabatHackathon.API
// Author           : Guilherme Branco Stracini
// Created          : 27/03/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 27/03/2023
// ***********************************************************************
// <copyright file="Utils.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Security.Cryptography;
using System.Text;

namespace TalabatHackathon.API;

/// <summary>
/// Class Utils.
/// </summary>
public static class Utils
{
    /// <summary>
    /// Gets the MD5 hash.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>System.String.</returns>
    public static string GetMd5Hash(this string input)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(input));

        var result = new StringBuilder();

        foreach (var t in hash)
        {
            result.Append(t.ToString(@"x2"));
        }

        return result.ToString();
    }

    /// <summary>
    /// Reads the fully.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>System.Byte[].</returns>
    public static byte[] ReadFully(this Stream input)
    {
        var buffer = new byte[16 * 1024];
        using var ms = new MemoryStream();
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            ms.Write(buffer, 0, read);
        }

        return ms.ToArray();
    }
}
