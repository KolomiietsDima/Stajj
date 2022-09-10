using AutoMapper;
using Microsoft.Extensions.Configuration;


namespace Staj
{
    public class ChatServices : IChatServices
    {
        private readonly data.Repositories.ChatRepository repository;
        private readonly IMapper mapper;
        public ChatServices(IConfiguration configuration)
        {
            this.repository = new data.Repositories.ChatRepository(configuration);
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Chat, ChatModel>().ReverseMap();
            }).CreateMapper();
        }

        public List<PublicChat> GetAllPrivateUsersChats(string UserId)
        {
            var all = repository.GetAllPrivateUsersChats(UserId);
            if (all is null)
                return null;
            

            return all;
        }
        public List<Chat> GetAllPublicUsersChats(string UserId)
        {
            var all = repository.GetAllPublicUsersChats(UserId);
            if (all is null)
                return null;


            return all;
        }
        

        public List<Users> GetUsersFromChat(int ChatId,string UserId)
        {
            var all = repository.GetUsersFromChat(ChatId,UserId);
            if (all is null)
                return null;


            return all;
        }

    }
}
