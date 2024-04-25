using DataAccessLayer.Context;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
