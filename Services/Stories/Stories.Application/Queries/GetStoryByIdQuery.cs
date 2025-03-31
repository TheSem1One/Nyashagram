using MediatR;
using Stories.Application.Responses;

namespace Stories.Application.Queries
{
    public class GetStoryByIdQuery : IRequest<GetStoryByIdResponse>
    {
        public string StoryId { get; set; } = null!;
    }
}

