using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public class MessageResponse
    {

     
        public int Id { get; set; }

     
        public string UserId { get; set; } = string.Empty;

        
        public int ChatId { get; set; }


        public string body { get; set; } = string.Empty;

        public DateTime DataCreated { get; set; }
        public string FirstName { set; get; } = string.Empty;

        public string LastName { set; get; } = string.Empty;
        public string DeletedUser { get; set; } = string.Empty;

        public int FId { get; set; }


        public string FUserId { get; set; } = string.Empty;


        public int FChatId { get; set; }


        public string Fbody { get; set; } = string.Empty;

        public DateTime FDataCreated { get; set; }
        public string FFirstName { set; get; } = string.Empty;

        public string FLastName { set; get; } = string.Empty;
        public string FDeletedUser { get; set; } = string.Empty;

    }
}
