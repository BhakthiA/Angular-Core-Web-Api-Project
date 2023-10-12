using JWT.Model.Config;
using JWT.Model.CustomModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data.DBRepository.Dropdown
{
    public class DropdownServicesRepo : BaseRepository, IDropdownRepo
    {
        public readonly IConfiguration configuration;
        public DropdownServicesRepo(IConfiguration _configuration, IOptions<DataBaseConfig> connection) : base(_configuration, connection)
        {
            configuration = _configuration;
        }

        public async Task<List<CityModel>> GetCity(int id)
        {
            var parameters = new { ListName = "City", id = id };
            IEnumerable<CityModel> result = await QueryAsync<CityModel>("[dbo].[sp_DropdownList]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<CountryModel>> GetCountry()
        {
            var parameters = new { ListName = "Country" };
            IEnumerable<CountryModel> result = await QueryAsync<CountryModel>("[dbo].[sp_DropdownList]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<DepartmentModel>> GetDepartment()
        {
            var parameters = new { ListName = "Department" };
            IEnumerable<DepartmentModel> result = await QueryAsync<DepartmentModel>("[dbo].[sp_DropdownList]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<StateModel>> GetState(int id)
        {
            var parameters = new { ListName = "State", id = id };
            IEnumerable<StateModel> result = await QueryAsync<StateModel>("[dbo].[sp_DropdownList]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
