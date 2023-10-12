using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service.Register
{
    public interface IRegisterServices
    {
        Task<int> Register(RegisterModel registerData);
        Task<int> CheckEmail(string email);
    }
}
