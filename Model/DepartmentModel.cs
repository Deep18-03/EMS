﻿using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "These field must be no more than 100 characters.")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
