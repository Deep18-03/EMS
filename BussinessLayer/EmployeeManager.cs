using BussinessLayer.Interface;
using DataAccessLayer.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinessLayer
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeData _employeeData;
        public EmployeeManager(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees(string SearchByEmpTag,string SearchByFirstName, string SearchByEmail)
        {
            var employees = _employeeData.GetAllEmployees();

            if (!String.IsNullOrEmpty(SearchByEmpTag))
            {
                employees = employees.Where(s => s.EmpTagNumber.ToLower().Contains(SearchByEmpTag.Trim().ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(SearchByFirstName))
            {
                employees = employees.Where(s => s.FirstName.ToLower().Contains(SearchByFirstName.Trim().ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(SearchByEmail))
            {
                employees = employees.Where(s => s.EmailAddress.ToLower().Contains(SearchByEmail.Trim().ToLower())).ToList();
            }
            return employees;
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
