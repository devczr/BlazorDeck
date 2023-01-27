using BlazorDeck.Client.Extensions;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorDeck.Client.Authentication;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ISessionStorageService _sessionStorage;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
            if (userSession is null)
                return await Task.FromResult(new AuthenticationState(_anonymous));

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.Username),
                new Claim(ClaimTypes.Role, userSession.Role)
            }, "JwtAuth"));
            //17:15

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        catch
        {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

    //call this method when users login or logout to update session storage & notify blazor about auth state change
    public async Task UpdateAuthenticationState(UserSession? userSession)
    {
        ClaimsPrincipal claimsPrincipal;

        // if the user session is not null then the user is trying to login, else they're logging out
        if (userSession is not null)
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.Username),
                new Claim(ClaimTypes.Role, userSession.Role)
            }));
            userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpiresIn);
            await _sessionStorage.SaveItemEncryptedAsync("UserSession", userSession);
        }
        else
        {
            claimsPrincipal = _anonymous;
            await _sessionStorage.RemoveItemAsync("UserSession");
        }

        //notify blazor about auth state change
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    //for Razor components to get jwt token from session storage, needed to consume apis
    public async Task<string> GetToken()
    {
        var result = string.Empty;

        try
        {
            //check token expiration
            var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
            if (userSession is not null && DateTime.Now < userSession.ExpiryTimeStamp)
                result = userSession.Token;
        }
        catch
        {

        }
        return result;
    }

}
