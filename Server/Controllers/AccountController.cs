using BlazorDeck.Server.Authentication;
using BlazorDeck.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserAccountService _userAccountService;
        public AccountController(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]


        public ActionResult<UserSession> Login([FromBody] LoginRequest loginRequest)
        {
            var jwtAuthManager = new JwtAuthManager(_userAccountService);
            var userSession = jwtAuthManager.GenerateJwtToken(loginRequest.Username, loginRequest.Password);

            if (userSession is null)
                return Unauthorized();
            else
                return userSession;
        }
    }
}
