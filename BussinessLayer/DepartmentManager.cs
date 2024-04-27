using BussinessLayer.Interface;
using DataAccessLayer.Interface;
using EMS.Common;
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

        public string AddDepartment(DepartmentModel model)
        {
            try
            {
                bool departmentExists = _departmentData.DepartmentExists(model.DepartmentName);

                if (departmentExists)
                {
                    return AppConstant.alreadyExists;
                }
                else
                {
                    _departmentData.AddDepartment(model);

                    return AppConstant.addedSuccessfully;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the business logic while adding department", ex);
            }
           
        }
    }
}
