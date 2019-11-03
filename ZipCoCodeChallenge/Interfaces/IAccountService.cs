using System.Collections.Generic;
using ZipCoCodeChallenge.Models;

namespace ZipCoCodeChallenge.Interfaces
{
    public interface IAccountService
    {
       

        string CreateAccount(string email);

        IEnumerable<AccountDetails> GetAllAccounts();
    }
}
