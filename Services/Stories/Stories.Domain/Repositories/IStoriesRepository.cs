using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Stories.Domain.Entity;

namespace Stories.Domain.Repositories
{
    public interface IStoriesRepository
    {
        Task<IEnumerable<Short>> GetPost();
        Task<IEnumerable<Short>> GetStoriesNickName(string nickName);
        Task<Short> GetStoriesById(string id);
        Task<string> CreatePost(string Dto);
        Task<bool> DeletePost(string id);
    }
}
