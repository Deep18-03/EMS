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
            catch (Exception)
            {

                throw;
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
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool DepartmentExists(string departmentName)
        {
            try
            {
                return _context.Departments.Any(d => d.DepartmentName.Trim().ToLower() == departmentName.Trim().ToLower());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
