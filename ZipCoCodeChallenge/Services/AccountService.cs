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
                UserDetails user = _context.Users.FirstOrDefault(x => email == x.EmailAddress);

                if (user == null)
                {
                    return ("User doesn't exist");
                }

                if (user.MonthlySalary < 1000)
                {
                    return "Can't create user account!";
                }

                var newAccount = new AccountDetails
                {
                    User = user,
                    IsActive = true

                };

                _context.Accounts.Add(newAccount);
                _context.SaveChanges();

            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

            return "Account Created!";
        }


        public string CreateAccount(UserDetails userDetails)
        {

            try
            {
                UserDetails user = _context.Users.FirstOrDefault(x => userDetails.EmailAddress == x.EmailAddress);

                if (user == null)
                {
                    return ("User doesn't exist");
                }

                if (user.MonthlySalary < 1000)
                {
                    return "Can't create user account!";
                }

                var newAccount = new AccountDetails
                {
                    User = user,
                    IsActive = true

                };

                _context.Accounts.Add(newAccount);
                _context.SaveChanges();

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
