using AutoMapper;
using Microsoft.Extensions.Configuration;
using Staj;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public class MessageServices :IMessageServices
    {
        private readonly data.Repositories.MessageRepository repository;
        private readonly IMapper mapper;
        public MessageServices(IConfiguration configuration)
        {
            this.repository = new data.Repositories.MessageRepository(configuration);
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Message, MessageModel>().ReverseMap();
            }).CreateMapper();
        }

        public List<MessageResponse> GetChatMessages(int ChatId,PaginationModel paginationModel = null)
        {
            if (paginationModel == null)
            {
                if (repository.GetChatMessages(ChatId) is null)
                    return null;
                else
                    repository.GetChatMessages(ChatId);

            }
            var skip = (paginationModel.PageNumber - 1) * paginationModel.PageSize;


            var all = repository.GetChatMessages(ChatId);
            var messages = all.Skip(skip).Take(paginationModel.PageSize).ToList(); 
            if (messages is null)
                return null;


            return messages;
        }
        public Response CreateMessage(MessageModel m)
        {

            var entityMessage = mapper.Map<MessageModel, Message>(m);


            return repository.CreateMessage(entityMessage);
        }
        public Response CreateMessageForward(MessageModel m,int Id_MessageForward)
        {

            var entityMessage = mapper.Map<MessageModel, Message>(m);


            return repository.CreateMessageForward(entityMessage,Id_MessageForward);
        }
        public Response DeleteMessage(int id)
        {

            return repository.DeleteMessage(id);
        }

        public Response DeleteMessageOnlyForUser(string id, int messageId)
        {

            return repository.DeleteMessageOnlyForUser(id,messageId);
        }

    }
}
