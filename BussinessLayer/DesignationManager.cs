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
    public class DesignationManager : IDesignationManager
    {
        private IDesignationData _designationData;
        public DesignationManager(IDesignationData designationData)
        {
            _designationData = designationData;
        }
        public IEnumerable<DesignationModel> GetDesignationDropdownList()
        {
            return _designationData.GetDesignationDropdownList();
        }

        public string AddDesignation(DesignationModel model)
        {
            try
            {
                bool designationExists = _designationData.DesignationExists(model.DesignationName);

                if (designationExists)
                {
                    return AppConstant.alreadyExists;
                }
                else
                {
                    _designationData.AddDesignation(model);

                    return AppConstant.addedSuccessfully;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the business logic while adding designation", ex);
            }
        
        }
    }
}
