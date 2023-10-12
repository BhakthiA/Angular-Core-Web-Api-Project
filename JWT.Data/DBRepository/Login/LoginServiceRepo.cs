using JWT.Model.Config;
using JWT.Model.CustomModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data.DBRepository.Login
{
    public class LoginServiceRepo : BaseRepository, ILoginRepo
    {
        public readonly IConfiguration configuration;
        public LoginServiceRepo(IConfiguration _configuration, IOptions<DataBaseConfig> connection) : base(_configuration, connection)
        {
            configuration = _configuration;
        }

        public async Task<int> Login(LoginModel loginData)
        {
            var parameters = new { Email = loginData.Email, Password = loginData.Password };
            return await QueryFirstOrDefaultAsync<int>("sp_LoginStudent", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
