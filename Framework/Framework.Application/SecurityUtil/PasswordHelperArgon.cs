using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Application.SecurityUtil;

public static class PasswordHelperArgon
{
    public static string EncodePasswordArgon2(string pass)
    {
        var salt = GenerateSalt();
        using var argon2 = new Argon2i(Encoding.UTF8.GetBytes(pass));
        argon2.Salt = Encoding.UTF8.GetBytes(salt);
        argon2.DegreeOfParallelism = 8; // تنظیم تعداد پارالل‌ها
        argon2.Iterations = 4; // تعداد دفعات اجرای الگوریتم
        argon2.MemorySize = 65536; // مقدار حافظه مورد استفاده

        byte[] hash = argon2.GetBytes(32); // طول هش به 32 بایت تنظیم شده است
        return Convert.ToBase64String(hash);
    }

    // تولید Salt تصادفی برای Argon2
    public static string GenerateSalt(int length = 16)
    {
        byte[] saltBytes = new byte[length];
        RandomNumberGenerator.Fill(saltBytes); // استفاده از RandomNumberGenerator به جای RNGCryptoServiceProvider
        return Convert.ToBase64String(saltBytes);
    }
}