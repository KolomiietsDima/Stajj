using Staj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public interface IChatServices
    {
        public List<PublicChat> GetAllPrivateUsersChats(string UserId);
        public List<Users> GetUsersFromChat(int ChatId, string UserId);
        public List<Chat> GetAllPublicUsersChats(string UserId);
    }
}
