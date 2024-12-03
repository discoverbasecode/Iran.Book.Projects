using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileUtil.Interfaces;

public interface IFtpFileService
{
    Task SaveFileAsync(IFormFile file, string directoryPath, CancellationToken cancellationToken = default);
    Task<string> SaveFileAndGenerateNameAsync(IFormFile file, string directoryPath, CancellationToken cancellationToken = default);
    Task SaveStreamAsync(Stream stream, string directoryPath, string fileName, CancellationToken cancellationToken = default);
    Task DeleteFileAsync(string directoryPath, string fileName, CancellationToken cancellationToken = default);
    Task DeleteFileAsync(string filePath, CancellationToken cancellationToken = default);
    Task DeleteDirectoryAsync(string directoryPath, CancellationToken cancellationToken = default);
}