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
    public class Message
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("UserId", TypeName = "varchar(200)")]
        [Required]
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; } = string.Empty;

        [Column("ChatId", TypeName = "int")]
        [Required]
        [ForeignKey("Chat")]
        public int ChatId { get; set; }

        [Column("Body", TypeName = "ntext")]
        public string body { get; set; } = string.Empty;

        [Column("DataCreated", TypeName = "datetime")]
        [Required]
        public DateTime DataCreated { get; set; }

        [Column("DeletedUser", TypeName = "varchar(200)")]
        public string DeletedUser { get; set; } = string.Empty;

        public Users user { get; set; }

        public Chat chat { get; set; }

        public List<MessageReply> messageReplies { get; set; }
    }
}
