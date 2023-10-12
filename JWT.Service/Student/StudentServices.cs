using JWT.Data.DBRepository.Student;
using JWT.Model.CustomModel;
using JWT.Service.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service.Student
{
    public class StudentServices :IStudentServices
    {
        private readonly IStudentRepo repo;
        public StudentServices(IStudentRepo _repo)
        {
             repo = _repo;
        }

        public async Task<StudentModel> DeleteStudent(int id)
        {
            return await repo.DeleteStudent(id);
        }

        public async Task<List<StudentModel>> GetAllStudents()
        {
           return await repo.GetAllStudents();
        }

        public async Task<StudentModel> GetOneStudent(int id)
        {
           return await repo.GetOneStudent(id);
        }

        public async Task<int> UpdateStudent(int Id, string FirstName, string LastName, string Email, string Contact, DateTime DateOfBirth,string Gender, string Address, int DepartmentId, int CountryId, int StateId, int CityId)
        {
            return await repo.UpdateStudent(Id, FirstName, LastName, Email, Contact, DateOfBirth, Gender, Address, DepartmentId, CountryId, StateId, CityId);
        }
    }
}
