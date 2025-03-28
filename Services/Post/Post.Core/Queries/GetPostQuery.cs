using MediatR;
using Post.Application.Responses;
using Post.Domain.Reposetories;

namespace Post.Application.Queries
{
    public class GetPostQuery : IRequest<IList<GetPostResponse>>
    {
         
    }
}
