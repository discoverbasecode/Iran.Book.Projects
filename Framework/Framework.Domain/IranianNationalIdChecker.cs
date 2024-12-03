using System.Text.RegularExpressions;

namespace Framework.Domain;
public class IranianNationalIdChecker
{
    public static bool IsValid(string nationalId)
    {
        if (string.IsNullOrWhiteSpace(nationalId) || !Regex.IsMatch(nationalId, @"^\d{10}$"))
            return false;

        var code = nationalId.PadLeft(10, '0');

        if (Convert.ToInt32(code.Substring(3, 6)) == 0)
            return false;

        var lastNumber = Convert.ToInt32(code.Substring(9, 1));
        var sum = 0;

        for (var i = 0; i < 9; i++)
        {
            sum += Convert.ToInt32(code.Substring(i, 1)) * (10 - i);
        }

        sum = sum % 11;

        return sum < 2 ? lastNumber == sum : lastNumber == 11 - sum;
    }
}