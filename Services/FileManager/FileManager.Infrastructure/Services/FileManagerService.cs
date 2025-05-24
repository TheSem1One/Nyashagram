using FileManager.Domain.Repositories;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using File = FileManager.Domain.Entities.File;

namespace FileManager.Infrastructure.Services
{
    public class FileManagerService
         (FileManagerContext imageContext, FileHelper fileHelper) : IFileManagerRepository
    {
        private readonly FileManagerContext _imageContext = imageContext;
        private readonly FileHelper _fileHelper = fileHelper;
        public async Task<string> SaveFileAsync(IFormFile file)
        {

            var nameFile = _fileHelper.SaveFile(file);
            var image = new File() { FileUrl = nameFile.Result };
            await _imageContext.Files.AddAsync(image);
            await _imageContext.SaveChangesAsync();
            return nameFile.Result;
        }
    }
}
