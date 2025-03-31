using FileManager.Domain.Entities;
using FileManager.Domain.Reposetories;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;

namespace FileManager.Infrastructure.Repositories
{
    public class FileManagerRepository
        (ImageContext imageContext, FileHelper fileHelper) : IFileManagerReposetory
    {
        private readonly ImageContext _imageContext = imageContext;
        private readonly FileHelper _fileHelper = fileHelper;
        public async Task<string> SaveFileAsync(IFormFile file)
        {

            var nameFile = _fileHelper.SaveFile(file);
            var image = new Image { ImageUrl = nameFile };
            await _imageContext.Images.AddAsync(image);
            await _imageContext.SaveChangesAsync();
            return nameFile;
        }
    }
}
