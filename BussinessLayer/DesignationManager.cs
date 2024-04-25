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

        public bool AddDesignation(DesignationModel model)
        {
            return _designationData.AddDesignation(model);
        }
    }
}
