using Microsoft.AspNetCore.Http;

namespace FileManager.Domain.Repositories
{
    public interface IFileManagerRepository
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}
