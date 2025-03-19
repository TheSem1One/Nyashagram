using FileManager.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;

namespace FileManager.Domain.Reposetories
{
    public interface IFileManagerReposetory
    {
        Task<string> SaveFileAsync(FileDTO file);
        Task<bool> DeleteImage(string fileNameWithExtension);
    }
}
