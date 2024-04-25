using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDepartmentData
    {
        IEnumerable<DepartmentModel> GetDepartmentDropdownList();
        bool AddDepartment(DepartmentModel model);
    }
}
