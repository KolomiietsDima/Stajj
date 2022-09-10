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
    public class MessageModel
    {
       
        public int Id { get; set; }

       
        public string UserId { get; set; } = string.Empty;

       
        public int ChatId { get; set; }

        
        public string body { get; set; } = string.Empty;

        public DateTime DataCreated { get; set; }
        public string DeletedUser { get; set; } = string.Empty;
    }
}
