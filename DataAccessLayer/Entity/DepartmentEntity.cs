using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    [Table("Department")]
    public class DepartmentEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // Navigation property
        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}
