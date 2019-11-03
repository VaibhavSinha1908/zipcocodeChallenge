using System.Collections.Generic;
using ZipCoCodeChallenge.Models;

namespace ZipCoCodeChallenge.Interfaces
{
    public interface IAccountService
    {
        string CreateAccount(UserDetails user);

        IEnumerable<AccountDetails> GetAllAccounts();
    }
}
