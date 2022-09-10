using Staj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public interface IMessageServices
    {
        public List<MessageResponse> GetChatMessages(int ChatId, PaginationModel paginationModel);
        public Response CreateMessage(MessageModel m);
        public Response DeleteMessage(int id);
        public Response DeleteMessageOnlyForUser(string id, int messageId);
        public Response CreateMessageForward(MessageModel m, int Id_MessageForward);
    }
}
