using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Staj
{
    public class LoginModel
    {
       
        public string Email { get; set; } = string.Empty;

       
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


    }
}
