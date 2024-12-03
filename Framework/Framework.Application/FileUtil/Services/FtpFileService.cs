using System.Net;
using Framework.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileUtil.Services;


public class FtpFileService : IFtpFileService
{
    private readonly string _ftpServer = "ftp://130.185.79.155/public_html";

    private NetworkCredential CreateNetworkCredential()
    {
        return new NetworkCredential("pz16162", "G9xna4oN");
    }

    public async Task SaveFileAsync(IFormFile file, string directoryPath, CancellationToken cancellationToken = default)
    {
        string currentDir = ConstructFtpPath(directoryPath);
        byte[] bytes = await ReadFileBytesAsync(file, cancellationToken);
        string path = $"{currentDir}/{file.FileName}";

        await UploadFileToFtpAsync(path, bytes, cancellationToken);
    }

    public async Task<string> SaveFileAndGenerateNameAsync(IFormFile file, string directoryPath, CancellationToken cancellationToken = default)
    {
        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        string currentDir = ConstructFtpPath(directoryPath);
        byte[] bytes = await ReadFileBytesAsync(file, cancellationToken);
        string path = $"{currentDir}/{fileName}";

        await UploadFileToFtpAsync(path, bytes, cancellationToken);
        return fileName;
    }

    public async Task SaveStreamAsync(Stream stream, string directoryPath, string fileName, CancellationToken cancellationToken = default)
    {
        string currentDir = ConstructFtpPath(directoryPath);
        byte[] bytes = await ReadStreamBytesAsync(stream, cancellationToken);
        string path = $"{currentDir}/{fileName}";

        await UploadFileToFtpAsync(path, bytes, cancellationToken);
    }

    public async Task DeleteFileAsync(string directoryPath, string fileName, CancellationToken cancellationToken = default)
    {
        string filePath = $"{_ftpServer}{directoryPath.RemoveWWWroot()}/{fileName}";
        await DeleteFtpFileAsync(filePath, cancellationToken);
    }

    public async Task DeleteFileAsync(string filePath, CancellationToken cancellationToken = default)
    {
        string fullFilePath = $"{_ftpServer}{filePath.RemoveWWWroot()}";
        await DeleteFtpFileAsync(fullFilePath, cancellationToken);
    }

    public async Task DeleteDirectoryAsync(string directoryPath, CancellationToken cancellationToken = default)
    {
        string directoryPathFtp = $"{_ftpServer}{directoryPath.RemoveWWWroot()}";
        await DeleteFtpDirectoryAsync(directoryPathFtp, cancellationToken);
    }

    private async Task UploadFileToFtpAsync(string filePath, byte[] bytes, CancellationToken cancellationToken)
    {
        var request = (FtpWebRequest)WebRequest.Create(new Uri(filePath));
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = CreateNetworkCredential();
        request.UseBinary = true;
        request.ContentLength = bytes.Length;

        cancellationToken.ThrowIfCancellationRequested();

        await using (var ftpStream = await request.GetRequestStreamAsync())
        {
            int bufferSize = 8192; // 8 KB buffer size
            int offset = 0;
            while (offset < bytes.Length)
            {
                cancellationToken.ThrowIfCancellationRequested();
                int bytesToWrite = Math.Min(bufferSize, bytes.Length - offset);
                await ftpStream.WriteAsync(bytes, offset, bytesToWrite, cancellationToken);
                offset += bytesToWrite;
            }
        }

        using (var response = (FtpWebResponse)await request.GetResponseAsync())
        {
            // Optionally log response.StatusDescription
        }
    }

    private async Task DeleteFtpFileAsync(string filePath, CancellationToken cancellationToken)
    {
        var request = (FtpWebRequest)WebRequest.Create(new Uri(filePath));
        request.Method = WebRequestMethods.Ftp.DeleteFile;
        request.Credentials = CreateNetworkCredential();

        using (var response = (FtpWebResponse)await request.GetResponseAsync())
        {
            // Optionally log response.StatusDescription
        }
    }

    private async Task DeleteFtpDirectoryAsync(string directoryPath, CancellationToken cancellationToken)
    {
        var request = (FtpWebRequest)WebRequest.Create(new Uri(directoryPath));
        request.Method = WebRequestMethods.Ftp.RemoveDirectory;
        request.Credentials = CreateNetworkCredential();

        using (var response = (FtpWebResponse)await request.GetResponseAsync())
        {
            // Optionally log response.StatusDescription
        }
    }

    private string ConstructFtpPath(string directoryPath)
    {
        string currentDir = _ftpServer;
        string[] subDirs = directoryPath.RemoveWWWroot().Split('/');
        foreach (var subDir in subDirs)
        {
            currentDir = $"{currentDir}/{subDir}";
            CreateDirectory(currentDir).Wait(); // Blocking call for simplicity, consider refactoring.
        }

        return currentDir;
    }

    private async Task CreateDirectory(string directoryPath)
    {
        try
        {
            var reqFTP = (FtpWebRequest)WebRequest.Create(directoryPath);
            reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = CreateNetworkCredential();
            using (var response = (FtpWebResponse)await reqFTP.GetResponseAsync())
            {
                // Optionally log response.StatusDescription
            }
        }
        catch (Exception)
        {
            // Directory may already exist; ignore.
        }
    }

    private async Task<byte[]> ReadFileBytesAsync(IFormFile file, CancellationToken cancellationToken)
    {
        await using var stream = file.OpenReadStream();
        byte[] bytes = new byte[file.Length];
        await stream.ReadAsync(bytes, 0, (int)file.Length, cancellationToken);
        return bytes;
    }

    private async Task<byte[]> ReadStreamBytesAsync(Stream stream, CancellationToken cancellationToken)
    {
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream, cancellationToken);
        return memoryStream.ToArray();
    }
}

public static class FtpTextHelper
{
    public static string RemoveWWWroot(this string text)
    {
        return text.Replace("wwwroot", "");
    }
}
