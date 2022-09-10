using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace Staj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private IMessageServices _MessageServicesDomain;
        private IUserServices _userServices;
        private readonly IMapper _mapper;
        public MessageController(IMessageServices services, IUserServices userServices, IMapper mapper)
        {

            _MessageServicesDomain = services;
            _userServices = userServices;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetChatMessages", Name = "GetChatMessages")]
        public IActionResult GetChatMessages(int ChatId,[FromQuery]PaginationQuery paginationQuery)
        {

            var PaginationFilter = _mapper.Map<PaginationModel>(paginationQuery);
            List<MessageResponse> res = _MessageServicesDomain.GetChatMessages(ChatId, PaginationFilter);

            var postsResponse = res;
            var paginationResponse = new PagedResponse<MessageResponse>(postsResponse);

            if (res != null)
                return Ok(paginationResponse);
            else
                throw new Exception("Messages not found");
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CreateMessage", Name = "CreateMessage")]
        public IActionResult CreateMessage(MessageModel model,int Id_MessageForward)
        {
           


             MessageModel m = new MessageModel() { body = model.body, ChatId = model.ChatId, UserId = _userServices.GetMyId(), DataCreated = DateTime.Now };
             Response res = new Response();

             if (Id_MessageForward == 0)
                {
                res = _MessageServicesDomain.CreateMessage(m);
               
                 }
             else {  res = _MessageServicesDomain.CreateMessageForward(m, Id_MessageForward); }
            
             if (res != null)
                 return Ok(res);
               else
                 throw new Exception("Messages not found");
            
                


               



            
           
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("DeleteMessage", Name = "DeleteMessage")]
        public IActionResult DeleteMessage(int Id)
        {

           


            Response res = _MessageServicesDomain.DeleteMessage(Id);


            if (res != null)
                return Ok(res);
            else
                throw new Exception("Messages not found");
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("DeleteMessageOnlyForUser", Name = "DeleteMessageOnlyForUser")]
        public IActionResult DeleteMessageOnlyForUser(MessageModel m)
        {




            Response res = _MessageServicesDomain.DeleteMessageOnlyForUser(_userServices.GetMyId(), m.Id);


            if (res != null)
                return Ok(res);
            else
                throw new Exception("Messages not found");
        }


    }

}
