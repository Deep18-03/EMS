using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public class DepartmentData : IDepartmentData
    {
        private readonly EMSDbContext _context;

        public DepartmentData(EMSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DepartmentModel> GetDepartmentDropdownList()
        {
            try
            {
                return _context.Departments
                .Select(e => new DepartmentModel
                {
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.DepartmentName
                })
                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the data access layer for getting department list", ex);
            }
        }

        public void AddDepartment(DepartmentModel model)
        {
            try
            {
                
                if (model != null)
                {
                    var _department = new DepartmentEntity
                    {
                        DepartmentName = model.DepartmentName.Trim().ToUpper(),
                    };

                    _context.Departments.Add(_department);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the data access layer for adding department", ex);
                throw;
            }
        }

        public bool DepartmentExists(string departmentName)
        {
            try
            {
                return _context.Departments.Any(d => d.DepartmentName.Trim().ToLower() == departmentName.Trim().ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the data access layer for department lready exists", ex);
                throw;
            }
        }
    }
}
