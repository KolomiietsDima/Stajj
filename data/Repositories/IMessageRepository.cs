using Staj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public interface IMessageRepository
    {
        public List<MessageResponse> GetChatMessages(int ChatId);
        public Response CreateMessage(Message m);
        public Response DeleteMessage(int id);
        public Response DeleteMessageOnlyForUser(string id, int messageId);
        public Response CreateMessageForward(Message m, int Id_MessageForward);
    }
}
