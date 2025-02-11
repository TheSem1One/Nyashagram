using Auth.Domain.Entities.AuthEntities;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    public class AuthController :ControllerBase
    {
        [HttpPost("auth")]
        public IActionResult Login([FromBody] LogModel login)
        {
            
        }
    }
}
