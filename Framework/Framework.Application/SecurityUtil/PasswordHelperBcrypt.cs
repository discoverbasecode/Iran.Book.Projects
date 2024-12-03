namespace Framework.Application.SecurityUtil;

public static class PasswordHelperBcrypt
{
    public static string EncodePasswordBcrypt(string pass)
    {
        return BCrypt.Net.BCrypt.HashPassword(pass);
    }

    public static bool VerifyPasswordBcrypt(string enteredPassword, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
    }
}