using BussinessLayer.Interface;
using DataAccessLayer.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DepartmentManager : IDepartmentManager
    {
        private IDepartmentData _departmentData;
        public DepartmentManager(IDepartmentData departmentData)
        {
            _departmentData = departmentData;
        }
        public IEnumerable<DepartmentModel> GetDepartmentDropdownList()
        {
            return _departmentData.GetDepartmentDropdownList();
        }

        public bool AddDepartment(DepartmentModel model)
        {
            return _departmentData.AddDepartment(model);
        }
    }
}
