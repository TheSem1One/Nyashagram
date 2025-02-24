using Asp.Versioning;
using Auth.Domain.Entities.AuthEntities;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
  
    public class ApiController :ControllerBase
    {
    }
}
