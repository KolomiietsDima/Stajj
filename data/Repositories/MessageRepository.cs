using Microsoft.Extensions.Configuration;
using Staj;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }
        public MessageRepository(IConfiguration config)
        {
            _context = new AppDbContext(config);
        }
        public List<MessageResponse> GetChatMessages(int ChatId)
        {
            List<Message> messages = new List<Message>();

            messages = _context.Message.Where(p => p.ChatId == ChatId).ToList();
                  
           
            List<MessageResponse> messagesResponse = new List<MessageResponse>();   
            foreach (var item in messages)
            {
                Message messageForward = new Message();
                Users userForward = new Users();
                MessageReply messageReply = _context.MessageReply.FirstOrDefault(m => m.Id_MessageForwarded == item.Id);
                if (messageReply!=null)
                {
                     messageForward = _context.Message.FirstOrDefault(p => p.Id == messageReply.Id_MessageForward) ?? new Message();
                     userForward = _context.Users.FirstOrDefault(p => p.Id == messageForward.UserId) ?? new Users();
                }
               
                Users u = _context.Users.FirstOrDefault(p => p.Id == item.UserId);
                messagesResponse.Add(new MessageResponse 
                { ChatId = item.ChatId, DataCreated = item.DataCreated, Id = item.Id, UserId = item.UserId, body = item.body, LastName = u.LastName, FirstName = u.FirstName, DeletedUser = item.DeletedUser,
                    FId = messageForward.Id, FUserId = messageForward.UserId, FChatId = messageForward.ChatId, Fbody = messageForward.body, FDataCreated = messageForward.DataCreated, FFirstName = userForward.FirstName,
                    FLastName = userForward.LastName, FDeletedUser = messageForward.DeletedUser });
            }
            if (messagesResponse == null)
            {
                return null;
            }
            else
            {          

                return messagesResponse.OrderByDescending(x => x.DataCreated).ToList();
            }


        }
        public Response CreateMessage(Message m)
        {
            Message message = new Message() { body = m.body, UserId = m.UserId,ChatId=m.ChatId,DataCreated=m.DataCreated,DeletedUser =m.DeletedUser };
            if (message.body.Length > 0  )
            {
                _context.Add(message);
                _context.SaveChanges();
                return new Response { Message = "Done" };
            }
            return new Response { Status = "Error" };
            




        }
        public Response CreateMessageForward(Message m, int Id_MessageForward)
        {
            Message message = new Message() { body = m.body, UserId = m.UserId, ChatId = m.ChatId, DataCreated = m.DataCreated, DeletedUser = m.DeletedUser };

            if (message.body.Length > 0)
            {
                _context.Add(message);
                _context.SaveChanges();
            }
           

            message =   _context.Message.FirstOrDefault(p => p.UserId == m.UserId && p.ChatId == m.ChatId && p.DataCreated == m.DataCreated);
            if (message != null)
            {
                MessageReply messageReply = new MessageReply() { Id_MessageForward = Id_MessageForward, Id_MessageForwarded = message.Id };
                _context.Add(messageReply);
                _context.SaveChanges();
                return new Response { Message = "Done" };
            }

            return new Response { Message = "Error" };


        }

        public Response DeleteMessage(int id)
        {
            MessageReply messageReply = new MessageReply();
            messageReply = _context.MessageReply.FirstOrDefault(m => m.Id_MessageForward == id || m.Id_MessageForwarded == id);
            if (messageReply != null)
            {
                _context.Remove(messageReply);
            }
            Message mes = new Message();
            mes = _context.Message.FirstOrDefault(p => p.Id == id);
            if (mes is null)
                return new Response { Message = "Not Found" };

            _context.Remove(mes);
            
            _context.SaveChanges();
            return new Response { Message = "Done" };




        }
        public Response DeleteMessageOnlyForUser(string id,int messageId)
        {

            Message mes = new Message();
            mes = _context.Message.FirstOrDefault(p => p.Id == messageId);
            if (mes is null)
                return new Response { Message = "Not Found" };

            mes.DeletedUser = id;

            _context.SaveChanges();
            return new Response { Message = "Done" };




        }

    }
}
