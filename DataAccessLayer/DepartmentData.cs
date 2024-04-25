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

        public bool AddDepartment(DepartmentModel model)
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
