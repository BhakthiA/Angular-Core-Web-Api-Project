using Dapper;
using JWT.Model.Config;
using JWT.Model.CustomModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data.DBRepository.Student
{
    public class StudentServiceRepo : BaseRepository, IStudentRepo
    {
        public readonly IConfiguration configuration;
        public StudentServiceRepo(IConfiguration _configuration, IOptions<DataBaseConfig> connection) : base(_configuration, connection)
        {
            configuration = _configuration;
        }

        public async Task<StudentModel> DeleteStudent(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Stud_Id", id);
            var result = await QueryFirstOrDefaultAsync<StudentModel>("sp_DeleteStudent", parameter, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<StudentModel>> GetAllStudents()
        {
            var student = await QueryAsync<StudentModel>("sp_GetAllStudents", commandType: CommandType.StoredProcedure);
            return student.ToList();
        }

        public async Task<StudentModel> GetOneStudent(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Stud_Id", id);
            var result = await QueryFirstOrDefaultAsync<StudentModel>("sp_GetOneStudent", parameter, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> UpdateStudent(int Id, string FirstName, string LastName, string Email, string Contact, DateTime DateOfBirth,string Gender, string Address, int DepartmentId, int CountryId, int StateId, int CityId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Stud_Id", Id);
            parameter.Add("FirstName", FirstName);
            parameter.Add("LastName",LastName);
            parameter.Add("Email",Email);
            parameter.Add("Contact", Contact);
            parameter.Add("DateOfBirth", DateOfBirth);
            parameter.Add("Gender", Gender);
            parameter.Add("Address", Address);
            parameter.Add("DepartmentId", DepartmentId);
            parameter.Add("CountryId",CountryId);
            parameter.Add("StateId",StateId);
            parameter.Add("CityId",CityId);
            var result = await QueryFirstOrDefaultAsync<int>("sp_UpdateStudent", parameter, commandType: CommandType.StoredProcedure);
            return result;
        }

        
    }
}
