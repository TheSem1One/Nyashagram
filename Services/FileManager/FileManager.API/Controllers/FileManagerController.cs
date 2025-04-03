using FileManager.Application.Features.FileManager;
using FileManager.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.API.Controllers
{
    public class FileManagerController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<FileManagerResponse>> SaveFileAsync([FromForm] CreateFileCommand file)
        {
            var result = await _mediator.Send(file);
            return Ok(result);
        }
    }
}
