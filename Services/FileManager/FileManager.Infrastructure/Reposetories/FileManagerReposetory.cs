using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Entities;
using FileManager.Domain.Reposetories;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FileManager.Infrastructure.Reposetories
{
    public class FileManagerReposetory
        (ImageContext imageContext, FileHelper fileHelper, IConfiguration configuration) : IFileManagerReposetory
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly FileHelper _fileHelper = fileHelper;
        private readonly ImageContext _imageContext = imageContext;

        async Task<IEnumerable<string>> IFileManagerReposetory.CreateImage(List<IFormFile> image)
        {
            List<Image> imageUrl = fileHelper.GetImageUrl(image);
            foreach (var formFile in imageUrl)
            {
                await _imageContext.Images.AddAsync(formFile);
                await _imageContext.SaveChangesAsync();
            }
            await _imageContext.SaveChangesAsync();
            return imageUrl.Select(img => img.ImageUrl).ToList();
        }

        async Task<bool> IFileManagerReposetory.DeleteImage(string imageUrl)
        {
            _imageContext.Remove(imageUrl);
            return true;
        }
    }
}
