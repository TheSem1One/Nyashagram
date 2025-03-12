using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using FileManager.Domain.Entities;

namespace FileManager.Infrastructure.Helpers
{
    public class FileHelper(IWebHostEnvironment environment)
    {
        private readonly string directory;
        private readonly IWebHostEnvironment _environment = environment;
        public List<Image> GetImageUrl(List<IFormFile> file)
        {
            List<Image> imagePath = new List<Image>();
            var wwwPath = _environment.WebRootPath;
            var path = Path.Combine(wwwPath, directory);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var url in file)
            {
                var exetsion = Path.GetExtension(url.FileName);
                var newFileName = $"{Guid.NewGuid()}{exetsion}";
                var fullPath = Path.Combine(path, newFileName);
                using var fileStream = new FileStream(fullPath, FileMode.Create);
                imagePath.Add(new Image
                {
                    ImageUrl = fullPath
                });
            }




            return imagePath;
        }
    }
}
