using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public interface IUserServices
    {
        public string GetMyId();
        public bool CreateUser(UserModel user);
    }
}
