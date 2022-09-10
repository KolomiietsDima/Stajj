using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
namespace Staj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        
        private readonly IConfiguration _configuration;
        private IUserServices _UserServicesDomain;
        private AppDbContext _context;
        public AuthController(AppDbContext _context,  IConfiguration configuration, IUserServices services)
        {

            _UserServicesDomain = services;
            _configuration = configuration;
            this._context = _context;
        }

        [HttpPost("Register")]
        public async Task<Response> Register(RegisterModel model)
        {
            if (model != null)
            {
                var passwordHash = PasswordHash.CreatePasswordHash(model.Password);
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                UserModel user = new UserModel() {Email = model.Email,FirstName= model.FirstName,LastName= model.LastName,Password = passwordHash,Id = GuidString};

                var result = _UserServicesDomain.CreateUser(user);
                if (result)
                {
                    return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
                }
                else
                {
                    return new Response { Status = "Error", Message = "Something gone wrong" };

                }

            }
            return new Response { Status = "Error", Message = "Something gone wrong" };

        }



        [HttpPost("Login")]
        public async Task<Response> Login(LoginModel model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            // validate
            if (user == null || !PasswordHash.VerifyPasswordHash(model.Password, user.Password))
                throw new Exception("Username or password is incorrect");



            var ISSUER = _configuration["TokenSettings:ISSUER"];
            var AUDIENCE = _configuration["TokenSettings:AUDIENCE"];
            var KEY = _configuration["TokenSettings:KEY"];
            var encodedJwt = TokenManager.GenerateToken(user, ISSUER, AUDIENCE,KEY);
            return new Response { Status = "Success", Message = encodedJwt, Id = user.Id };






        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetMyId", Name = "GetMyId")]
        public IActionResult GetMyId()
        {


           var res = _UserServicesDomain.GetMyId();

            if (res != null)
                return Ok(res);
            else
                throw new Exception("Messages not found");
        }


    }
}
