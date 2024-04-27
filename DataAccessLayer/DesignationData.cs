using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DesignationData : IDesignationData
    {
        private readonly EMSDbContext _context;

        public DesignationData(EMSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DesignationModel> GetDesignationDropdownList()
        {
            try
            {
                return _context.Designations
                                 .Select(e => new DesignationModel
                                 {
                                     DesignationId = e.DesignationId,
                                     DesignationName = e.DesignationName
                                 })
                                 .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the data access layer for getting designation list", ex);
            }
        }

        public bool AddDesignation(DesignationModel model)
        {
            try
            {
                if (model != null)
                {
                    var _designation = new DesignationEntity
                    {
                        DesignationName = model.DesignationName.Trim().ToUpper(),
                    };

                    _context.Designations.Add(_designation);
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the data access layer for adding designation ", ex);
            }
        }

        public bool DesignationExists(string designationName)
        {
            try
            {
                return _context.Designations.Any(d => d.DesignationName.Trim().ToLower() == designationName.Trim().ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in the data access layer for designation already exists", ex);
            }
        }
    }
}
