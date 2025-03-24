using MediatR;
using Post.Application.Responses;

namespace Post.Application.Queries
{
    public class GetPostByCreatorQuerry : IRequest<IList<GetPostResponse>>
    {
        public string NickName { get; set; }
    }
}
