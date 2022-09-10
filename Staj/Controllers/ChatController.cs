using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Staj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private IChatServices _ChatServicesDomain;
        private IUserServices _userServices;
        public ChatController(IChatServices services,IUserServices userServices)
        {

            _ChatServicesDomain = services;
            _userServices = userServices;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllPrivateUsersChats", Name = "GetAllPrivateUsersChats")]
        public IActionResult GetAllPrivateUsersChats()
        {


            List<PublicChat> res = _ChatServicesDomain.GetAllPrivateUsersChats(_userServices.GetMyId());

            if (res != null)
                return Ok(res);
            else
                throw new Exception("Genres not found");
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllPublicUsersChats", Name = "GetAllPublicUsersChats")]
        public IActionResult GetAllPublicUsersChats()
        {


            List<Chat> res = _ChatServicesDomain.GetAllPublicUsersChats(_userServices.GetMyId());

            if (res != null)
                return Ok(res);
            else
                throw new Exception("Genres not found");
        }
        

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetUsersFromChat", Name = "GetUsersFromChat")]
        public IActionResult GetUsersFromChat(int ChatId)
        {


            List<Users> res = _ChatServicesDomain.GetUsersFromChat(ChatId, _userServices.GetMyId());

            if (res != null)
                return Ok(res);
            else
                throw new Exception("Messages not found");
        }

    }
}
