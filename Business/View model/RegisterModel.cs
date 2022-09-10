using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Staj
{
    public class RegisterModel
    {
        
        public string FirstName { get; set; } = string.Empty;
       
        public string LastName { get; set; } = string.Empty;
       
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

       
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
