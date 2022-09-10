using Staj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public interface IChatRepository
    {
        public List<PublicChat> GetAllPrivateUsersChats(string UserId);
        public List<Users> GetUsersFromChat(int ChatId, string userId);
        public List<Chat> GetAllPublicUsersChats(string UserId);
        public Chat FindPrivateChatById(int ChatId);
    }
}
