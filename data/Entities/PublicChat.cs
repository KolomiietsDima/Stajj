using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public class PublicChat 
    {
        public string UserId { set; get; } = string.Empty;
        public string FirstName { set; get; } = string.Empty;

        public string LastName { set; get; } = string.Empty;
        public int ChatId { set; get; } 

        public string Type { set; get; } = string.Empty;

    }
}