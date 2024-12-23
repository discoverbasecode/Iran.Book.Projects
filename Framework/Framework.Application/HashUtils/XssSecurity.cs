using Ganss.Xss;

namespace Framework.Application.HashUtils;

public static class XssSecurity
{

    private static readonly HtmlSanitizer HtmlSanitizerInstance = new()
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