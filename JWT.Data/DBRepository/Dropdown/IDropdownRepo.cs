using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data.DBRepository.Dropdown
{
    public interface IDropdownRepo
    {
       Task<List<CountryModel>> GetCountry();

        Task<List<StateModel>> GetState(int id);

        Task<List<CityModel>> GetCity(int id);

        Task<List<DepartmentModel>> GetDepartment();

    }
}
