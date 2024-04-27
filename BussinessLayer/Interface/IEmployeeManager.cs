using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface IEmployeeManager
    {
        IEnumerable<EmployeeModel> GetAllEmployees( string SearchByEmpTag, string SearchByFirstName, string SearchByEmail);
        string AddEmployee(EmployeeModel model);
        EmployeeModel GetEmployeeById(int id);
        string UpdateEmployee(EmployeeModel model);
        string DeleteEmployee(int id);
    }
}
