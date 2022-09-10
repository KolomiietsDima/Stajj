using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity.EntityFramework;


namespace Staj
{
    [Table("Users")]
    public class Users : IdentityUser
    {

        [Key]
        [Column("UserId", TypeName = "varchar(200)")]
        public string Id { get; set; }

        [Column("FirstName", TypeName = "varchar(200)")]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Column("LastName", TypeName = "varchar(200)")]
        [Required]
        public string LastName { get; set; } = string.Empty;
        
        [Column("Email", TypeName = "varchar(200)")]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Column("Password", TypeName = "varchar(200)")]
        [Required]
        public string Password { get; set; } = string.Empty;

        public List<Message> messages { get; set; }
        public List<Participants> participants { get; set; }

    }
}

