using JWT.Common;
using JWT.Model.Config;
using JWT.Model.CustomModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data.DBRepository.Register
{
    public class RegisterServiceRepo : BaseRepository, IRegisterRepo
    {
        public readonly IConfiguration configuration;

        public RegisterServiceRepo(IConfiguration _configuration, IOptions<DataBaseConfig> connection) : base(_configuration, connection)
        {
            configuration = _configuration;
        }

        public async Task<int> CheckEmail(string email)
        {
            var parameter = new { Email = email };
            int data = await QueryFirstOrDefaultAsync<int>("sp_CheckEmail", parameter, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<int> Register(RegisterModel registerData)
        {
            try
            {

                var parameters = new
                {
                    FirstName = registerData.FirstName,
                    LastName = registerData.LastName,
                    Email = registerData.Email,
                    Password = registerData.Password,
                    Gender = registerData.Gender,
                    DateOfBirth = registerData.DateOfBirth,
                    Contact = registerData.Contact,
                    Address = registerData.Address,
                    DepartmentId = registerData.DepartmentId,
                    CountryId = registerData.CountryId,
                    StateId = registerData.StateId,
                    CityId = registerData.CityId,
                    ProfilePic = registerData.ProfilePic,
                    PasswordHash = registerData.PasswordHash,
                    PasswordSalt = registerData.PasswordSalt,
                    VerificationToken= registerData.VerificationToken,
                };
                var result = await ExecuteAsync<int>("sp_RegisterStudent", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
