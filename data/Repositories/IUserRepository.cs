using Staj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public interface IUserRepository
    {
        public bool CreateUser(Users user);
    }
}
