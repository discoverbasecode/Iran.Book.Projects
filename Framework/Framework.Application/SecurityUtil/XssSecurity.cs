using Ganss.Xss;

namespace Framework.Application.SecurityUtil;

public static class XssSecurity
{

    private static readonly HtmlSanitizer HtmlSanitizerInstance = new HtmlSanitizer
    {
        KeepChildNodes = true,
        AllowDataAttributes = true
    };

    public static string SanitizeText(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return text;
        }

        return HtmlSanitizerInstance.Sanitize(text);
    }
}