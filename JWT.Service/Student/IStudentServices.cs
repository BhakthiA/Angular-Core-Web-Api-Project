using JWT.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service.Register
{
    public interface IStudentServices
    {
        Task<List<StudentModel>> GetAllStudents();

        Task<StudentModel> GetOneStudent(int id);

        Task<StudentModel> DeleteStudent(int id);

        //Task<int> UpdateStudent(UpdateStudentModel updateData);

        Task<int> UpdateStudent(int Id, string FirstName, string LastName, string Email, string Contact, DateTime DateOfBirth,string Gender, string Address, int DepartmentId, int CountryId, int StateId, int CityId);
    }
}
