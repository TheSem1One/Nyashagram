using MediatR;
using Post.Application.Responses;

namespace Post.Application.Commands
{
    public class CreatePostCommand : IRequest<CreatePostResponse>
    {
        public string ImageUrl { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
