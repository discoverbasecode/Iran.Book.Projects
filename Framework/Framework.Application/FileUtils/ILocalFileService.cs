using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileUtils;

public interface ILocalFileService
{
    Task DeleteDirectory(string directoryPath, CancellationToken cancellationToken = default);
    Task DeleteFile(string path, string fileName, CancellationToken cancellationToken = default);

    Task DeleteFile(string filePath, CancellationToken cancellationToken = default);

    Task SaveFile(IFormFile file, string directoryPath, CancellationToken cancellationToken = default);

    Task SaveFile(IFormFile file, string directoryPath, string fileName, CancellationToken cancellationToken = default);

    Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath, CancellationToken cancellationToken = default);
}