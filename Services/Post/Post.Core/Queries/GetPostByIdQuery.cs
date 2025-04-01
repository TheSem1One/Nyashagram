using MediatR;
using Post.Application.Responses;

namespace Post.Application.Queries
{
    public class GetPostByIdQuery : IRequest<GetPostByIdResponse>
    {
        public string PostId { get; set; } = null!;
    }
}
