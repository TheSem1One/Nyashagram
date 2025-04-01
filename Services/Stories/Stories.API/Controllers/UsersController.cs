using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stories.Application.Queries;

namespace Stories.API.Controllers
{
    public class UsersController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet("{nickName}/stories")]
        public async Task<ActionResult<IList<GetStoryByCreatorQuery>>> GetStoryByCreator([FromRoute] string nickName)
        {
            var query = new GetStoryByCreatorQuery { NickName = nickName };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
