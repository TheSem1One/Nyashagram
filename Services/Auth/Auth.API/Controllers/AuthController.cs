using Auth.Application.Profiles;
using Auth.Domain.Entities.AuthEntities;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController :ControllerBase
    {
        protected readonly UserAuth _logIn;
        public AuthController(UserAuth logIn)
        {
            _logIn=logIn;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LogModel logModel)
        {
            _logIn.UserLogin(logModel);
            return(Ok());
        }


        [HttpPost("regis")]
        public IActionResult Regis([FromBody] RegisModel regModel)
        {

            return (Ok());
        }
    }
}
