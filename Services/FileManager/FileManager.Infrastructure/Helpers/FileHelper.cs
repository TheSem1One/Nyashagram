using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FileManager.Infrastructure.Helpers
{
    public class FileHelper(IWebHostEnvironment environment)
    {
        public string SaveFile(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentException(nameof(file));
            }

            var contentPath = environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var decomposedFileName = file.FileName.Split(".");
            var ext = decomposedFileName[^1];
            var fileName = $"{Guid.NewGuid().ToString()}.{ext}";
            var fileNamePath = Path.Combine(path, fileName);
            using var stream = new FileStream(fileNamePath, FileMode.Create);
            file.CopyToAsync(stream);
            return fileName;
        }
    }
}
