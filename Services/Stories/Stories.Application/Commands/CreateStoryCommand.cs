using MediatR;
using Stories.Application.Responses;

namespace Stories.Application.Commands
{
    public class CreateStoryCommand : IRequest<CreateStoryResponse>
    {
        public string StoriesImageUrl { get; set; } = null!;
        public string CreatorNickName { get; set; } = null!;
    }
}
