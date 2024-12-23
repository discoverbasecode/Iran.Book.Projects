using Konscious.Security.Cryptography;
using System.Text;

namespace Framework.Application.HashUtils;

public class HashingArgon
{
    public static string HashPassword(string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        using var argon2 = new Argon2id(passwordBytes);
        argon2.Salt = GenerateSalt();
        argon2.DegreeOfParallelism = 8;
        argon2.MemorySize = 65536;
        argon2.Iterations = 4;

        byte[] hashedPassword = argon2.GetBytes(32);

        return Convert.ToBase64String(hashedPassword);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        byte[] storedHash = Convert.FromBase64String(hashedPassword);

        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        using var argon2 = new Argon2id(passwordBytes);
        argon2.DegreeOfParallelism = 8;
        argon2.MemorySize = 65536;
        argon2.Iterations = 4;

        byte[] computedHash = argon2.GetBytes(32);
        return storedHash.SequenceEqual(computedHash);
    }

    private static byte[] GenerateSalt()
    {
        using var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        byte[] salt = new byte[16];
        rng.GetBytes(salt);
        return salt;
    }
}
