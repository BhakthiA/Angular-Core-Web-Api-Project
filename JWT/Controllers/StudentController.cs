using JWT.Common;
using JWT.Model.CustomModel;
using JWT.Service.Dropdown;
using JWT.Service.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class StudentController : ControllerBase
    {
        private IStudentServices student;

        public StudentController(IStudentServices _student,IDropdownService list)
        {
            student = _student;
        }

        [HttpGet("GetAllStudent")]
        public async Task<ApiResponse<StudentModel>> GetAllStudent()
        {
            try
            {
                ApiResponse<StudentModel> response = new ApiResponse<StudentModel>() { Data = new List<StudentModel>() };
                List<StudentModel> result = await student.GetAllStudents();
                //var result = await student.GetAllStudents(); We Can use this line also for the same use of above line.
                response.Data = result;
                response.Success = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("GetOneStudent")]
        public async Task<ApiResponse<StudentModel>> GetOneStudent(int id)
        {
            try
            {
                ApiResponse<StudentModel> response = new ApiResponse<StudentModel>();
                var result = await student.GetOneStudent(id);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "No Data Found";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Success";
                    response.Data = new List<StudentModel>() { result };
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ApiResponse<StudentModel>> DeleteStudent(int id)
        {
            try
            {
                ApiResponse<StudentModel> response = new ApiResponse<StudentModel>();
                var result = await student.DeleteStudent(id);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "No Data Found";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Success";
                    response.Data = new List<StudentModel>() { result };
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("UpdateStudent")]
        public async Task<BaseApiResponse> UpdateStudent(int Id, string FirstName, string LastName, string Email, string Contact, DateTime DateOfBirth,string Gender, string Address, int DepartmentId, int CountryId, int StateId, int CityId)
        {
            try
            {
                //ApiPostResponse<StudentModel> response = new ApiPostResponse<StudentModel>() { Data = new StudentModel() };
                BaseApiResponse response = new BaseApiResponse();



                var result = await student.UpdateStudent(Convert.ToInt16(Id),FirstName,LastName,Email,Contact,DateOfBirth,Gender,Address,DepartmentId,CountryId,StateId,CityId);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "No Data Found";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Success";
                    //response.Happy = result;
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
