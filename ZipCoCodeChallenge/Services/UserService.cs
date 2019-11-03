using System.Collections.Generic;
using System.Linq;
using ZipCoCodeChallenge.Interfaces;
using ZipCoCodeChallenge.Models;

namespace ZipCoCodeChallenge.Services
{
    public class UserService : IUserService
    {
        private readonly ZipPayContext _context;
        public UserService(ZipPayContext context)
        {
            _context = context;
        }

        public string AddUser(UserDetails userDetails)
        {
            if (_context.Users.Where(x => x.EmailAddress == userDetails.EmailAddress).Count() > 0)
            {
                return "User Exists";
            }

            //Save Changes.
            _context.Users.Add(userDetails);
            _context.SaveChanges();

            return "User Added";
        }

        public IEnumerable<UserDetails> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public UserDetails GetUser(int id)
        {
            return _context.Users.Find(id);
        }
    }
}