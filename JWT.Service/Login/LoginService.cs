using JWT.Data.DBRepository.Login;
using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo  loginRepo;
        public LoginService(ILoginRepo _loginRepo ) {
            loginRepo = _loginRepo;
        }
        public async Task<int> Login(LoginModel loginData)
        {
            return await loginRepo.Login(loginData);
        }
    }
}
