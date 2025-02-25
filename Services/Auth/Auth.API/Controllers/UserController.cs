using System.Net;
using Auth.Application.Commands;
using Auth.Application.Handlers;
using Auth.Application.Queries;
using Auth.Application.Responses;
using Auth.Domain.DTO;
using Auth.Domain.Entities;
using Auth.Domain.Entities.AuthEntities;
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
        [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UserResponse>> GetUserByNickName([FromHeader] string nickName)
        {
            var query = new GetUserQuery(nickName);
            var result = await _mediator.Send((query));
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateUser")]
        [ProducesResponseType(typeof(RegisterResponse),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<RegisterResponse>> CreateUser([FromBody] RegisterDTO registerDTO)
        {
            var command = new CreateUserCommand(registerDTO.Email,registerDTO.NickName,registerDTO.Password);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

