using JWT.Service.Dropdown;
using JWT.Service.Login;
using JWT.Service.Register;
using JWT.Service.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service
{
    public class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictionary = new Dictionary<Type, Type>()
            {
                {typeof (IDropdownService),typeof(DropdownServices) },
                {typeof (IRegisterServices),typeof(RegisterServices) },
                {typeof (ILoginService),typeof(LoginService) },
                {typeof (IStudentServices),typeof(StudentServices) },
            };

            return serviceDictionary;
        }

    }
}
