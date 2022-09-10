using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public class PagedResponse<T>
    {
        public PagedResponse()
        {

        }
        public PagedResponse(IEnumerable<T> limitresponse)
        {
            Data = limitresponse;
        }

        public IEnumerable<T> Data { get; set; }

        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }   


    }
}

