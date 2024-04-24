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
        IEnumerable<EmployeeModel> GetAllEmployees();
        bool AddEmployee(EmployeeModel model);
        EmployeeModel GetEmployeeById(int id);
        bool UpdateEmployee(EmployeeModel model);
        bool DeleteEmployee(int id);
    }
}
