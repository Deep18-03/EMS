﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDesignationData
    {
        IEnumerable<DesignationModel> GetDesignationDropdownList();
        bool AddDesignation(DesignationModel model);
        bool DesignationExists(string designationName);
    }
}
