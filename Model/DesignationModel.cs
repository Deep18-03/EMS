using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class DesignationModel
    {
        public int DesignationId { get; set; }

        [Required]
        public string DesignationName { get; set; }
    }
}
