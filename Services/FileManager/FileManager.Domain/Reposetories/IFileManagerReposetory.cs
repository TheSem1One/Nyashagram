using Microsoft.AspNetCore.Http;

namespace FileManager.Domain.Reposetories
{
    public interface IFileManagerReposetory
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}
