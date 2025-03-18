using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManager.Domain.Reposetories
{
    public interface IFileManagerReposetory
    {
        Task<IEnumerable<string>> CreateImage(List<IFormFile> files);
        Task<bool> DeleteImage(string imageUrl);
    }
}
