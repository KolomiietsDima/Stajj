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
    public class MessageReply
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("Id_MessageForward", TypeName = "int")]
        [Required]
        public int Id_MessageForward { get; set; } 

        [Column("Id_MessageForwarded", TypeName = "int")]
        [Required]
        public int Id_MessageForwarded { get; set; }

       
        public Message message { get; set; }

    }
}

