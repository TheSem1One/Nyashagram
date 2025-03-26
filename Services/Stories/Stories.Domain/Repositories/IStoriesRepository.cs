using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Stories.Domain.Entity;
using Stories.Domain.Entity.DTO;

namespace Stories.Domain.Repositories
{
    public interface IStoriesRepository
    {
        Task<IEnumerable<Short>> GetStoriesNickName(string nickName);
        Task<Short> GetStoriesById(string id);
        Task<string> CreateStories(ShortsDTO shortsDto);
        Task<bool> DeleteStories(string id);
    }
}
