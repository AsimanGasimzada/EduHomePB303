using Microsoft.AspNetCore.Http;

namespace EduHome.Business.Services.Abstractions;

public interface ICloudinaryService
{
    Task<string> FileCreateAsync(IFormFile file);
    Task<bool> FileDeleteAsync(string filePath);
}
