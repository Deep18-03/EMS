using DataAccessLayer.Context;
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
            return _context.Departments
                  .Select(e => new DepartmentModel
                  {
                      DepartmentId = e.DepartmentId,
                      DepartmentName = e.DepartmentName
                  })
                  .ToList();
        }
    }
}
