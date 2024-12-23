using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileUtils;
public static class FileValidation
{
    private static bool IsValidExtension(this IFormFile? file, HashSet<string> validExtensions)
    {
        if (file == null) return false;
        var extension = Path.GetExtension(file.FileName)?.ToLower();
        return extension != null && validExtensions.Contains(extension);
    }

    public static bool IsValidFile(this IFormFile file)
    {
        var validExtensions = new HashSet<string>
        {
            ".mp4", ".mp3", ".zip", ".rar", ".wav", ".docx", ".mmf", ".m4a", ".ogg",
            ".doc", ".pdf", ".txt", ".xls", ".xla", ".xlsx", ".ppt", ".pptx", ".gif",
            ".jpg", ".png", ".tif", ".wmv", ".bmp", ".wmf", ".log"
        };
        return file.IsValidExtension(validExtensions);
    }

    public static bool IsValidCompressFile(this IFormFile file)
    {
        var validExtensions = new HashSet<string> { ".zip", ".rar" };
        return file.IsValidExtension(validExtensions);
    }

    public static bool IsValidMp4File(this IFormFile file)
    {
        var validExtensions = new HashSet<string> { ".mp4" };
        return file.IsValidExtension(validExtensions);
    }

    public static bool IsValidImageFile(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return false;
        var validExtensions = new HashSet<string?> { ".jpg", ".png", ".bmp", ".svg", ".jpeg", ".webp" };
        return validExtensions.Contains(Path.GetExtension(fileName).ToLower());
    }
}