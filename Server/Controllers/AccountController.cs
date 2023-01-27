using BlazorDeck.Server.Authentication;
using BlazorDeck.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MudBlazor.CategoryTypes;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserAccountService _userAccountService;
        private readonly DataContext _context;

        public AccountController(UserAccountService userAccountService, DataContext context)
        {
            _userAccountService = userAccountService;
            _context = context;
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<UserAccount>> GetAccount(string username)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Username == username);
            if (account == null)
            {
                return NotFound("Sorry, account not found");
            }
            return Ok(account);
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


/*        [HttpGet]
        public async Task<ActionResult<List<UserAccount>>> GetAccounts()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return Ok(accounts);
        }*/


    }
}
