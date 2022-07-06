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
}