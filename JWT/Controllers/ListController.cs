using JWT.Common;
using JWT.Model.CustomModel;
using JWT.Service.Dropdown;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private IDropdownService List;
        public ListController(IDropdownService _List)
        {
            List = _List;
        }

        [HttpGet("GetDepartment")]
        public async Task<ApiResponse<DepartmentModel>> GetDepartment()
        {
            try
            {
                ApiResponse<DepartmentModel> response = new ApiResponse<DepartmentModel>()
                {
                    Data = new List<DepartmentModel>()
                };
                List<DepartmentModel> result = await List.GetDepartment();
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "No Data Found";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Success";
                    response.Data = result;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetCountry")]
        public async Task<ApiResponse<CountryModel>> GetCountry()
        {
            try
            {
                ApiResponse<CountryModel> response = new ApiResponse<CountryModel>()
                {
                    Data = new List<CountryModel>()
                };
                List<CountryModel> result = await List.GetCountry();
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "No Data Found";
                }
                else
                {
                    response.Success = true;

                    response.Message = "Success";

                    response.Data = result;

                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetState")]
        public  async Task<ApiResponse<StateModel>> GetState(int id)
        { 
            ApiResponse<StateModel> response = new ApiResponse<StateModel>()
            {
                Data = new List<StateModel>()
            };
            List<StateModel> result = await List.GetState(id);
            if (result == null)
            {

                response.Success = false;
                response.Message = "No Data Found";
            }
            else {
                response.Success = true;
                response.Message = "Success";
                response.Data = result;
            }
            return response;
        }

        [HttpGet("GetCity")]
        public  async Task<ApiResponse<CityModel>> GetCity(int id) {

            try
            {
                ApiResponse<CityModel> response = new ApiResponse<CityModel>()
                {
                    Data = new List<CityModel>()
                };
                List<CityModel> result = await List.GetCity(id);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "No Data Found";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Success";
                    response.Data = result;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
