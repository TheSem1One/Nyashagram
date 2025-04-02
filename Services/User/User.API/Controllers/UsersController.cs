using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Auth;
using User.Application.Features.Profile;
using User.Application.Responses;

namespace User.API.Controllers
{
    public class UsersController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPatch]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateProfileCommand command)
        {
            var result = await _mediator.Send((command));
            return Ok(result);
        }
    }
}
