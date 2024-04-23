using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    [Table("Employee")]
    public class EmployeeEntity
    {
        public int Emp_Id { get; set; }
        public string EmpTagNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int DepartmentId { get; set; }
        public DateTime Birthdate { get; set; }
        public int DesignationId { get; set; }

        // Navigation properties
        public DepartmentEntity Department { get; set; }
        public DepartmentEntity Designation { get; set; }
    }
}
