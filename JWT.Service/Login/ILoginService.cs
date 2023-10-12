using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service.Login
{
    public interface ILoginService
    {
        Task<int> Login(LoginModel loginData);
    }
}
