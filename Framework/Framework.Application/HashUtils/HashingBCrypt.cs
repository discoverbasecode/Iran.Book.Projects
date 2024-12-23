using BCrypt.Net;

namespace Framework.Application.HashUtils;

public static class HashingBCrypt
{
    private const int DefaultWorkFactor = 12;

    public static string HashPassword(string password, int workFactor = DefaultWorkFactor)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        if (workFactor < 4 || workFactor > 31)
            throw new ArgumentOutOfRangeException(nameof(workFactor), "Work factor must be between 4 and 31.");

        return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(workFactor));
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        if (string.IsNullOrEmpty(hashedPassword))
            throw new ArgumentException("Hashed password cannot be null or empty.", nameof(hashedPassword));

        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}