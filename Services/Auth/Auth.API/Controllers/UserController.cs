using System.Net;
using Auth.Application.Queries;
using Auth.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/nickName", Name = "GetUserByNickName")]
        [ProducesResponseType(typeof(UserResponse),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UserResponse>> GetUserByNickName(string nickName)
        {
            var query = new GetUserQuery(nickName);
            var result = await _mediator.Send((query));
            return Ok(result);
        }
    }
}
