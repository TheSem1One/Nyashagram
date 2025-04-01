using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.Application.Queries;
using Post.Application.Responses;

namespace Post.API.Controllers
{
    public class UsersController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{nickName}/posts")]
        public async Task<ActionResult<IList<GetPostResponse>>> GetPostByCreator([FromRoute] string nickName)
        {
            var query = new GetPostByCreatorQuery { NickName = nickName };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
