using BlazorDeck.Shared;

namespace BlazorDeck.Server.Authentication;

public class UserAccountService
{
    private readonly DataContext _context;
    public UserAccountService(DataContext context)
    {
        _context = context;
    }

    public UserAccount? GetSingleUserAccount(string username)
    {
        return _context.Accounts.FirstOrDefault(x => x.Username == username);

    }

}
