using Framework.Application.FileUtils;
using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileUtil.Services;

public class LocalFileService : ILocalFileService
{
    public async Task DeleteDirectory(string directoryPath, CancellationToken cancellationToken = default)
    {
        try
        {
            if (Directory.Exists(directoryPath))
            {
                await Task.Run(() => Directory.Delete(directoryPath, true), cancellationToken);
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error deleting directory {directoryPath}", ex);
        }
    }

    public async Task DeleteFile(string path, string fileName, CancellationToken cancellationToken = default)
    {
        try
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath), cancellationToken);
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error deleting file {fileName} at {path}", ex);
        }
    }

    public async Task DeleteFile(string filePath, CancellationToken cancellationToken = default)
    {
        try
        {
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath), cancellationToken);
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error deleting file at {filePath}", ex);
        }
    }

    public async Task SaveFile(IFormFile file, string directoryPath, CancellationToken cancellationToken = default)
    {
        if (file == null)
            throw new InvalidDataException("file is Null");

        var fileName = file.FileName;
        await SaveFileInternal(file, directoryPath, fileName, cancellationToken);
    }

    public async Task SaveFile(IFormFile file, string directoryPath, string fileName, CancellationToken cancellationToken = default)
    {
        if (file == null)
            throw new InvalidDataException("file is Null");

        await SaveFileInternal(file, directoryPath, fileName, cancellationToken);
    }

    public async Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath, CancellationToken cancellationToken = default)
    {
        if (file == null)
            throw new InvalidDataException("file is Null");

        var fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
            .Replace(":", "")
            .Replace(".", "") + Path.GetExtension(file.FileName);

        await SaveFileInternal(file, directoryPath, fileName, cancellationToken);
        return fileName;
    }

    private async Task SaveFileInternal(IFormFile file, string directoryPath, string fileName, CancellationToken cancellationToken)
    {
        var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath);

        if (!Directory.Exists(folderName))
            Directory.CreateDirectory(folderName);

        var path = Path.Combine(folderName, fileName);
        await using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream, cancellationToken);
        }
    }


}
