using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EmployeeModel
    {
        public int Emp_Id { get; set; }

        [Display(Name = "Emp Tag #")]
        [Required]
        public string EmpTagNumber { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
       
        [Required]
        public int DesignationId { get; set; }

        public string DepartmentName { get; set; }

        public string DesignationName { get; set; }

        public int Age { get; set; }

    }
}
