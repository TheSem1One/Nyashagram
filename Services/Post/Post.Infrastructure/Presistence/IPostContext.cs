using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Post.Infrastructure.Presistence
{
    public interface IPostContext
    {
        IMongoCollection<Domain.Entities.Post> Post { get; }

    } 
}
