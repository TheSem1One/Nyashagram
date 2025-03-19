using System.Net;
using FileManager.Application.Commands;
using FileManager.Application.Responses;
using FileManager.Domain.Entities.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.API.Controllers
{
    public class FileManagerController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("SaveFile")]
        [ProducesResponseType(typeof(FileManagerResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<FileManagerResponse>> SaveFileAsync([FromBody] FileDTO fileDto)
        {
            var result = await _mediator.Send(fileDto);
            return Ok(result);
        }
    }
}
