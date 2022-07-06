using System.Security.Cryptography;
using System.Text;

namespace TalabatHackathon.API;

public static class Utils
{
    public static string GetMd5Hash(this string input)
    {
        var algorithm = new MD5CryptoServiceProvider();

        var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

        var result = new StringBuilder();

        foreach (var t in hash)
        {
            result.Append(t.ToString(@"x2"));
        }

        return result.ToString();
    }

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