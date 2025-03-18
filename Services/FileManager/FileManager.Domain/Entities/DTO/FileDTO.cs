using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain.Entities.DTO
{
    public class FileDTO
    {
        List<IFormFile> Files { get; set; }
    }
}
