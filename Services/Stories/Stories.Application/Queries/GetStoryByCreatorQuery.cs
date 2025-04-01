using MediatR;
using Stories.Application.Responses;

namespace Stories.Application.Queries
{
    public class GetStoryByCreatorQuery : IRequest<IList<GetStoryResponse>>
    {
        public string NickName { get; set; } = null!;
    }
}
