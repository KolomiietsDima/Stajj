using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Staj
{
   public class UserServices: IUserServices
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly data.Repositories.UserRepository repository;
        public UserServices(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.repository = new data.Repositories.UserRepository(configuration);
            _httpContextAccessor = httpContextAccessor;
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UserModel>().ReverseMap();
            }).CreateMapper();

        }

       public string GetMyId()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext !=null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            }
            return result;
        }

        public bool CreateUser(UserModel user)
        {
            var entityUser = mapper.Map<UserModel, Users>(user);
            return repository.CreateUser(entityUser);

        }



    }
}
