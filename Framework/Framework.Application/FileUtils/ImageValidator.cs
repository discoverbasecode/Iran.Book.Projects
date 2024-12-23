using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileUtils;
public static class ImageValidator
{
    public static bool IsImage(this IFormFile? file)
    {
        if (file == null)
            return false;

        if (!FileValidation.IsValidImageFile(file.FileName))
            return false;
        try
        {
            using var stream = file.OpenReadStream();
            using var image = Image.FromStream(stream);
            return true;
        }
        catch
        {
            return false;
        }
    }
}