using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Model.CustomModel
{
    public class LoginModel
    {
       
        public string Email { get; set; }
       
        public string Password { get; set; }
    }


    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JWT_Token { get; set; }
    }
}
