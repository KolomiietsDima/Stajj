using Microsoft.Extensions.Configuration;
using Staj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace data.Repositories
{
    public class ChatRepository: IChatRepository
    {
        private AppDbContext _context;

        public ChatRepository(AppDbContext context)
        {
            _context = context;
        }
        public ChatRepository(IConfiguration config)
        {
            _context = new AppDbContext(config);
        }
        public Chat FindPrivateChatById(int ChatId)
        {

            var result = _context.Chat.FirstOrDefault(p => p.Id == ChatId && p.Type == "Private");
            if (result == null)
            {
                return null;
            }
            else
            {

                return result;
            }


        }

        public List<Users> GetUsersFromChat(int ChatId,string userId)
        {
            List<Users> users = new List<Users>();
            List < Participants> participants = new List<Participants>();
            participants = _context.Participants.Where(p => p.ChatId == ChatId && p.UserId != userId).ToList();
            List<string> usersId = new List<string>();
            foreach (var item in participants)
            {

                var result = _context.Users.FirstOrDefault(p => p.Id == item.UserId);
                if (result!=null)
                {
                    users.Add(result);
                }

                
            }

            return users;
            


        }

        public List<PublicChat> GetAllUsersFromChats(List<int> ChatId,string userId)
        {
            List<PublicChat> publicChats = new List<PublicChat>();  
            List<Users> users = new List<Users>();
            Participants participants = new Participants();
            List<string> usersId = new List<string>();
            for (int i = 0; i < ChatId.Count; i++)
            {
                participants = _context.Participants.FirstOrDefault(p => p.ChatId == ChatId[i] && p.UserId != userId);
                usersId.Add(participants.UserId);
                users.Add(_context.Users.FirstOrDefault(p => p.Id == usersId[i]));
                publicChats.Add(new PublicChat { ChatId = ChatId[i], FirstName = users[i].FirstName,LastName = users[i].LastName,UserId = users[i].Id,Type = "Private"});
            }
                
                 
          
            return publicChats;
        }


        public List<Chat> GetAllPublicUsersChats(string UserId)
        {
  
            List<Participants> ret = new List<Participants>();
            
            List<Chat> chats = new List<Chat>();
            ret = _context.Participants.Where(p => p.UserId == UserId).ToList();

            foreach (var item in ret)
            {
                var r = _context.Chat.FirstOrDefault(p => p.Type == "Public" && p.Id == item.ChatId);
                if (r != null)
                {
                    chats.Add(r);
                }

            }
         

            return chats;
        }




        public List<PublicChat> GetAllPrivateUsersChats(string UserId)
        {
            List<PublicChat> publicChats = new List<PublicChat>();
            List<Participants> ret = new List<Participants>();
            List<int> chatId = new List<int>();
            List<Chat> chats = new List<Chat>();
            ret = _context.Participants.Where(p => p.UserId == UserId).ToList();
           
            foreach (var item in ret)
            {
                var r = _context.Chat.FirstOrDefault(p => p.Type == "Private" && p.Id == item.ChatId);
                if (r != null)
                {
                    chats.Add(r);
                }
               
              
            }
            foreach (var item in chats)
            {
                chatId.Add(item.Id);



            }
          

            publicChats = GetAllUsersFromChats(chatId, UserId);


            return publicChats;
        }
    }
}
