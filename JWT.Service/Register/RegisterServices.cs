using JWT.Data.DBRepository.Register;
using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service.Register
{
    public class RegisterServices :IRegisterServices
    {
        private readonly IRegisterRepo repo;
        public RegisterServices(IRegisterRepo _repo)
        {
            repo = _repo;
        }

        public async Task<int> CheckEmail(string email)
        {
            return await repo.CheckEmail(email);
        }

        public async Task<int> Register(RegisterModel registerData)
        {
            return await repo.Register(registerData);
        }
    }
}
