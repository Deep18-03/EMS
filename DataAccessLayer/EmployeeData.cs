using CommonLayer;
using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Interface;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class EmployeeData : IEmployeeData
    {
        private readonly EMSDbContext _context;

        public EmployeeData(EMSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                var employees = (from employee in _context.Employees
                                 join desig in _context.Designations on employee.DepartmentId equals desig.DesignationId
                                 join dept in _context.Departments on employee.DepartmentId equals dept.DepartmentId
                                 select new EmployeeModel
                                 {
                                     Emp_Id = employee.Emp_Id,
                                     EmpTagNumber = employee.EmpTagNumber,
                                     FirstName = employee.FirstName,
                                     LastName = employee.LastName,
                                     EmailAddress = employee.EmailAddress,
                                     Birthdate = employee.Birthdate,
                                     DepartmentId = employee.DepartmentId,
                                     DepartmentName = dept.DepartmentName,
                                     DesignationId = employee.DesignationId,
                                     DesignationName = desig.DesignationName,
                                     Age = employee.Age
                                 }).ToList();

                return employees;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                if (model != null)
                {
                    var _employee = new EmployeeEntity
                    {
                        EmpTagNumber = model.EmpTagNumber.Trim(),
                        FirstName = char.ToUpper(model.FirstName[0]) + model.FirstName.Trim().Substring(1),
                        LastName = char.ToUpper(model.LastName[0]) + model.LastName.Trim().Substring(1),
                        EmailAddress = model.EmailAddress.Trim(),
                        DepartmentId = model.DepartmentId,
                        Birthdate = model.Birthdate,
                        DesignationId = model.DesignationId,
                        Age = Utility.CalculateAge(model.Birthdate)
                    };

                    _context.Employees.Add(_employee);
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            try
            {
                var employeeEntity = _context.Employees.FirstOrDefault(p => p.Emp_Id == id);

                if (employeeEntity == null)
                {
                    return null;
                }

                var employeeModel = new EmployeeModel
                {
                    Emp_Id = employeeEntity.Emp_Id,
                    EmpTagNumber = employeeEntity.EmpTagNumber,
                    FirstName = employeeEntity.FirstName,
                    LastName = employeeEntity.LastName,
                    EmailAddress = employeeEntity.EmailAddress,
                    DepartmentId = employeeEntity.DepartmentId,
                    Birthdate = employeeEntity.Birthdate,
                    DesignationId = employeeEntity.DesignationId,
                };

                return employeeModel;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public bool UpdateEmployee(EmployeeModel model)
        {
            try
            {
                if (model != null)
                {
                    var _employee = new EmployeeEntity
                    {
                        Emp_Id = model.Emp_Id,
                        EmpTagNumber = model.EmpTagNumber.Trim(),
                        FirstName = char.ToUpper(model.FirstName[0]) + model.FirstName.Trim().Substring(1),
                        LastName = char.ToUpper(model.LastName[0]) + model.LastName.Trim().Substring(1),
                        EmailAddress = model.EmailAddress.Trim(),
                        DepartmentId = model.DepartmentId,
                        Birthdate = model.Birthdate,
                        DesignationId = model.DesignationId,
                        Age = Utility.CalculateAge(model.Birthdate)
                    };
                    _context.Employees.Update(_employee);
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var data = _context.Employees.Where(p => p.Emp_Id == id).FirstOrDefault();
                if (data != null)
                {
                    _context.Employees.Remove(data);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}
