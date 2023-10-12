using JWT.Data.DBRepository.Dropdown;
using JWT.Data.DBRepository.Login;
using JWT.Data.DBRepository.Register;
using JWT.Data.DBRepository.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dataDictionary = new Dictionary<Type, Type>()
            {
                { typeof (IStudentRepo),typeof (StudentServiceRepo) },

                { typeof(ILoginRepo),typeof(LoginServiceRepo) },

                { typeof(IRegisterRepo),typeof(RegisterServiceRepo) },

                { typeof(IDropdownRepo),typeof(DropdownServicesRepo) },
            };
            return dataDictionary;
        }
    }
}
