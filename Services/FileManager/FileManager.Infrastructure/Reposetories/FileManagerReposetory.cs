using FileManager.Domain.Entities.DTO;
using FileManager.Domain.Reposetories;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Persistance;

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

        async Task<string> IFileManagerReposetory.SaveFileAsync(FileDTO file)
        {

            var nameFile = _fileHelper.SaveFile(file.Files);
            await _imageContext.AddAsync(nameFile);
            await _imageContext.SaveChangesAsync();
            return nameFile;
        }
    }
}
