using System.Security.Cryptography;
using System.Text;

namespace Framework.Application.HashUtils;


public static class HashingSHA256
{
    public static string EncodePasswordSha256(string pass, string salt)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] saltedPassword = Encoding.UTF8.GetBytes(pass + salt);
        byte[] hashBytes = sha256.ComputeHash(saltedPassword);

        StringBuilder sb = new StringBuilder();
        foreach (var t in hashBytes)
        {
            sb.Append(t.ToString("X2"));
        }
        return sb.ToString();
    }

    public static string GenerateSalt(int length = 16)
    {
        byte[] saltBytes = new byte[length];
        RandomNumberGenerator.Fill(saltBytes); 
        return Convert.ToBase64String(saltBytes);
    }
}