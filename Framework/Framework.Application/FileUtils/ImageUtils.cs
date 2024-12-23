using SixLabors.ImageSharp;

namespace Framework.Application.FileUtils;

public static class SoundUtils
{

    public static void SaveImage(string filePath, Image image)
    {
        using var fileStream = new FileStream(filePath, FileMode.Create);
        image.SaveAsJpeg(fileStream);
    }

    public static Image LoadImage(string filePath)
    {
        return Image.Load(filePath);
    }

}
