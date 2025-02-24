 
using Auth.Domain.Entities.AuthEntities;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController :ControllerBase
    {
      
        public AuthController( )
        {
            
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LogModel logModel)
        {
            
            return Ok();
        }


        [HttpPost("regis")]
        public IActionResult Regis([FromBody] Register regModel)
        {

            return Ok();
        }
    }
}
