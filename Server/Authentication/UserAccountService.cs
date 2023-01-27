namespace BlazorDeck.Server.Authentication;

public class UserAccountService
{


    private List<UserAccount> _userAccountList;


    public UserAccountService()
    {
        _userAccountList = new List<UserAccount>
        {
            new UserAccount { Username = "admin", Password = "admin", Role = "Administrator" },
            new UserAccount { Username = "user", Password = "user", Role = "User" },
        };
    }


    public UserAccount? GetUserAccount(string username)
    {
        //TODO: read user data from db

        return _userAccountList.FirstOrDefault(x => x.Username == username);
    }

}
