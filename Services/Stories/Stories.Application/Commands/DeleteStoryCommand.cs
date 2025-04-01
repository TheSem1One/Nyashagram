using MediatR;
using Stories.Application.Responses;

namespace Stories.Application.Commands
{
    public class DeleteStoryCommand : IRequest<DeleteStoryResponse>
    {
        public string StoryId { get; set; } = null!;
    }
}
