using JWT.Data.DBRepository.Dropdown;
using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service.Dropdown
{
    public class DropdownServices : IDropdownService
    {
        private readonly IDropdownRepo repo;
        public DropdownServices(IDropdownRepo _repo)
        {
            repo = _repo;
        }

        public async Task<List<CityModel>> GetCity(int id)
        {
            return await repo.GetCity(id);
        }

        public async Task<List<CountryModel>> GetCountry()
        {
            return await repo.GetCountry();
        }

        public async Task<List<DepartmentModel>> GetDepartment()
        {
           return await repo.GetDepartment();
        }

        public async Task<List<StateModel>> GetState(int id)
        {
            return await repo.GetState(id);
        }
    }
}
