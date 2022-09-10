using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Staj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public class UserRepository: IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public UserRepository(IConfiguration config)
        {
            _context = new AppDbContext(config);
        }
        public bool CreateUser(Users user)
        {

           
            if (user != null)
            {
                Users u = new Users() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password };


                _context.Add(u);
                _context.SaveChanges();
                return true;
            }     
                return false;
              

        }

    }
}
