using BussinessLayer.Interface;
using DataAccessLayer.Interface;
using EMS.Common;
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
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the business logic while getting employees", ex);
            }
           
        }

        public string AddEmployee(EmployeeModel model)
        {
            try
            {
                bool employeeExists = _employeeData.EmployeeExists(model.EmpTagNumber);
                if (employeeExists)
                {
                    return AppConstant.alreadyExists;
                }
                else
                {
                    _employeeData.AddEmployee(model);
                    return AppConstant.addedSuccessfully;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the business logic while adding employees", ex);
            }
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            try
            {
                return _employeeData.GetEmployeeById(id);

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the business logic while fetching employee", ex);
            }
        }

        public string UpdateEmployee(EmployeeModel model)
        {
            try
            {
                bool employeeExists = _employeeData.EmployeeExists(model.EmpTagNumber);
                if (employeeExists)
                {
                    return AppConstant.alreadyExists;
                }
                else
                {
                    _employeeData.UpdateEmployee(model);
                    return AppConstant.addedSuccessfully;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the business logic while updating employee", ex);
            }
            
        }

        public string DeleteEmployee(int id)
        {
            try
            {
                var employeeDeleted = _employeeData.DeleteEmployee(id);

                if (employeeDeleted)
                {
                    return AppConstant.deletedSuccessfully;
                }
                else
                {
                    return AppConstant.deletedSuccessfully;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the business logic while deleting employee", ex);
            }
        }


    }
}
