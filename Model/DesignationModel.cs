using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class DesignationModel
    {
        public int DesignationId { get; set; }

        [Required]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }
    }
}
