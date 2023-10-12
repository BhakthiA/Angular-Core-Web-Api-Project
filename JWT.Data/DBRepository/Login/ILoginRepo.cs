using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data.DBRepository.Login
{
    public interface ILoginRepo
    {
        Task<int> Login(LoginModel loginData);
    }
}
