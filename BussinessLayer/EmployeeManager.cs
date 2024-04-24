using BussinessLayer.Interface;
using DataAccessLayer.Interface;
using Model;
using System.Collections.Generic;

namespace BussinessLayer
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeData _employeeData;
        public EmployeeManager(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return _employeeData.GetAllEmployees();
        }

        public bool AddEmployee(EmployeeModel model)
        {
            return _employeeData.AddEmployee(model);
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            return _employeeData.GetEmployeeById(id);
        }

        public bool UpdateEmployee(EmployeeModel model)
        {
            return _employeeData.UpdateEmployee(model);
        }

        public bool DeleteEmployee(int id)
        {
            return _employeeData.DeleteEmployee(id);
        }

    }
}
