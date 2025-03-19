using Microsoft.AspNetCore.Http;
namespace FileManager.Domain.Entities.DTO
{
    public class FileDTO
    {
        public IFormFile Files { get; set; } = null!;
    }
}
