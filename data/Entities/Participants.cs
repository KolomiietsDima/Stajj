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
    public class Participants
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("UserId", TypeName = "varchar(200)")]
        [Required]
       
        public string UserId { get; set; } 

        [Column("ChatId", TypeName = "int")]
        [Required]
        
        public int ChatId { get; set; }

        public Chat chat { get; set; } 
        public Users user { get; set; }

    }
}
