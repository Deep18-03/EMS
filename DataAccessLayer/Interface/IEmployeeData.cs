using Model;
using System.Collections.Generic;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeData
    {
        IEnumerable<EmployeeModel> GetAllEmployees();
        bool AddEmployee(EmployeeModel model);
        EmployeeModel GetEmployeeById(int id);
        bool UpdateEmployee(EmployeeModel model);
        bool DeleteEmployee(int id);
        bool EmployeeExists(string empTagNumber);
    }
}
