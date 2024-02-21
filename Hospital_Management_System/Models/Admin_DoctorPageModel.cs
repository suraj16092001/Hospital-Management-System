using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Admin_DoctorPageModel
    {
        public int id { get; set; }
        public string qualification { get; set; }
        public string specialist { get; set; }
        public string gender  { get; set; }
        public string phone { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/DD/YYYY}")]
        public string DateOfBirth { get; set; } // age instead dob
        public string address { get; set; }
        public string profileImage { get; set; }
        public IFormFile imageFile { get; set; }
    }   
}
