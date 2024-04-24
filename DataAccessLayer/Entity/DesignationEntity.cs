using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    [Table("Designation")]
    public class DesignationEntity
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }

        // Navigation property
        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}
