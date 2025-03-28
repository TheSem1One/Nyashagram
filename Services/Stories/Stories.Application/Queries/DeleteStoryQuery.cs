using MediatR;
using Stories.Application.Responses;

namespace Stories.Application.Queries
{
    public class DeleteStoryQuery : IRequest<DeleteStoryResponse>
    {
        public string StoryId { get; set; }
    }
}
