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
    public class Chat
    {
        [Key]
        [Column("ChatId", TypeName = "int")]
        public int Id { get; set; }

        [Column("ChatName", TypeName = "varchar(200)")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("Type", TypeName = "varchar(200)")]
        [Required]
        public string Type { get; set; } = string.Empty;

        public List<Message> Messages { get; set; }

        public List<Participants> Participants { get; set; }
    }
}
