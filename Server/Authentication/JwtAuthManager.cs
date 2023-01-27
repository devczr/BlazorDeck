using BlazorDeck.Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorDeck.Server.Authentication;

public class JwtAuthManager
{
    public const string JWT_SECURITY_KEY = "tU3zrKz9UVB7GtQimot4N7kdKsy7FqGd";
    private const int JWT_TOKEN_VALIDITY_MINS = 20;

    UserAccountService _userAccountService;
    public JwtAuthManager(UserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }


    public UserSession? GenerateJwtToken(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return null;


        // validate user credentials - TODO check this async for better options
/*        Task<UserAccount> task = Task.Run<UserAccount>(async () => await _userAccountService.GetSingleUserAccount(username));
        var userAccount = task.Result;*/
        var userAccount = _userAccountService.GetSingleUserAccount(username);
        if (userAccount == null || userAccount.Password != password)
            return null;


        //generate JWT token and return user session object
        var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, userAccount.Username),
            new Claim(ClaimTypes.Role, userAccount.Role)
        });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = signingCredentials
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        var userSession = new UserSession
        {
            Username = userAccount.Username,
            Role = userAccount.Role,
            Token = token,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
        };

        return userSession;
    }


}
