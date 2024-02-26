using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Admin_PatientPageModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string? gender { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Contact must contain only numbers.")]
        public string? phone { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/DD/YYYY}")]
        public string? DateOfBirth { get; set; }
        [Required]
        public string? address { get; set; }
        [Required]
        public int register_id { get; set; }


    }
}
