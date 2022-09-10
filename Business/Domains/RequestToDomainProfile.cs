using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public class RequestToDomainProfile :Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationModel>();
        }
    }
}
