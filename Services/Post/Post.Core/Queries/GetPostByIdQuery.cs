using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Post.Application.Responses;

namespace Post.Application.Queries
{
    public class GetPostByIdQuery : IRequest<GetPostByIdResponse>
    {
        public string PostId { get; set; }
    }
}
