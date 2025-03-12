using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Entities;
using FileManager.Domain.Reposetories;
using FileManager.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;

namespace FileManager.Infrastructure.Reposetories
{
    public class FileManagerReposetory(ImageContext imageContext) : IFileManagerReposetory
    {
        private readonly ImageContext _imageContext=imageContext;
        async Task<IEnumerable<string>> IFileManagerReposetory.CreateImage(List<IFormFile> image)
        {
            List<Image> imageUrl = GetImageUrl(image);
            foreach (var formFile in imageUrl)
            {
                await _imageContext.Images.AddAsync(image);
                await _imageContext.SaveChangesAsync();
            }
           await _imageContext.Images.AddAsync(image);
           await _imageContext.SaveChangesAsync();
            return imageUrl;
        }

        async Task<bool> IFileManagerReposetory.DeleteImage(string imageUrl)
        {
            _imageContext.Remove(imageUrl);
            return true;
        }
    }
}
