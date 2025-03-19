using FileManager.Domain.Entities;
using FileManager.Domain.Entities.DTO;
using FileManager.Domain.Reposetories;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;

namespace FileManager.Infrastructure.Reposetories
{
    public class FileManagerReposetory
        (ImageContext imageContext, FileHelper fileHelper) : IFileManagerReposetory
    {
        private readonly ImageContext _imageContext = imageContext;
        private readonly FileHelper _fileHelper = fileHelper;

        async Task<bool> IFileManagerReposetory.DeleteImage(string fileName)
        {
            _imageContext.Remove(fileName);
            await _imageContext.SaveChangesAsync();
            return true;
        }

        async Task<string> IFileManagerReposetory.SaveFileAsync(IFormFile file)
        {

            var nameFile = _fileHelper.SaveFile(file);
            var image = new Image { ImageUrl = nameFile }; 
            await _imageContext.Images.AddAsync(image);
            await _imageContext.SaveChangesAsync();
            return nameFile;
        }
    }
}
