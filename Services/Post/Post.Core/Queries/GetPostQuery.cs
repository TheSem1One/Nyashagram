using MediatR;
using Post.Application.Responses;

namespace Post.Application.Queries
{
    public class GetPostQuery : IRequest<IList<GetPostResponse>>
    {

    }
}
