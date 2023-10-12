using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data.DBRepository.Register
{
    public interface IRegisterRepo
    {
        Task<int> Register(RegisterModel registerData);

        Task<int> CheckEmail(string email);
    }
}
