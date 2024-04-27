using System;
using System.ComponentModel.DataAnnotations;
using static CommonLayer.CustomValidation;

namespace Model
{
    public class EmployeeModel
    {
        public int Emp_Id { get; set; }

        [Display(Name = "Emp Tag #")]
        [MaxLength(20, ErrorMessage = "These field must be no more than 20 characters.")]
        [Required]
        public string EmpTagNumber { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [MaxLength(50, ErrorMessage = "These field must be no more than 50 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MaxLength(50, ErrorMessage = "These field must be no more than 50 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [MaxLength(100, ErrorMessage = "These field must be no more than 100 characters.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }

        [DataType(DataType.Date)]
        [NotThisYear(ErrorMessage = "Birthdate cannot be in the current year.")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public int DesignationId { get; set; }

        public string DepartmentName { get; set; }

        public string DesignationName { get; set; }

        public int Age { get; set; }

    }
}
