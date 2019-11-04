using System.Collections.Generic;
using System.Linq;
using ZipCoCodeChallenge.Interfaces;
using ZipCoCodeChallenge.Models;

namespace ZipCoCodeChallenge.Services
{
    public class AccountService : IAccountService
    {
        private readonly ZipPayContext _context;
        public AccountService(ZipPayContext context)
        {
            _context = context;
        }

        public string CreateAccount(string email)
        {

            try
            {
                UserDetails user = _context.Users.FirstOrDefault(x => email.ToLower() == x.EmailAddress.ToLower());

                //Check if User exists.
                if (user == null)
                {
                    return ("User doesn't exist");
                }

                //Check for Business use case.
                if (user.MonthlySalary < 1000)
                {
                    return "Can't create user account!";
                }

                //Check for duplicates
                if (_context.Accounts.FirstOrDefault(x => x.UserId == user.UserId && x.IsActive == true) != null)
                {
                    return "Account Exits";
                }
                else
                {
                    //create account
                    var newAccount = new AccountDetails
                    {
                        UserId = user.UserId,
                        IsActive = true

                    };

                    _context.Accounts.Add(newAccount);
                    _context.SaveChanges();
                }

            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

            return "Account Created!";
        }



        public IEnumerable<AccountDetails> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
