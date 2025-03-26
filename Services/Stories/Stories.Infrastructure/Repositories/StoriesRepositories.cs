using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Domain.Entity;
using Stories.Domain.Repositories;

namespace Stories.Infrastructure.Repositories
{
    public class StoriesRepositories : IStoriesRepository
    {
        public Task<string> CreateStories(string Dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStories(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Short>> GetStories()
        {
            throw new NotImplementedException();
        }

        public Task<Short> GetStoriesById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Short>> GetStoriesNickName(string nickName)
        {
            throw new NotImplementedException();
        }
    }
}
