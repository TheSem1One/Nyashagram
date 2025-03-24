using MediatR;
using Post.Application.Responses;
using Post.Domain.Reposetories;

namespace Post.Application.Queries
{
    public class GetPostQuerry : IRequest<IList<GetPostResponse>>
    {
         
    }
}
