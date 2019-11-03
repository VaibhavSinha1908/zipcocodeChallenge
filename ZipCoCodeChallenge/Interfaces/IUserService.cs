using System.Collections.Generic;
using ZipCoCodeChallenge.Models;

namespace ZipCoCodeChallenge.Interfaces
{
    public interface IUserService
    {
        string AddUser(UserDetails userDetails);
        IEnumerable<UserDetails> GetAllUsers();
        UserDetails GetUser(int id);
    }
}
