using MediatR;
using Post.Application.Responses;

namespace Post.Application.Commands
{
    public class DeletePostCommand : IRequest<DeletePostResponse>
    {
        public string PostId { get; set; } = null!;
    }
}
