using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Admin_PatientPageModel
    {
        public int id { get; set; }
        public string age { get; set; }

        public string gender { get; set; }

        public string phone { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY/MM/DD}")]
        public string DateOfBirth { get; set; }

        public string address { get; set; }

        public int register_id { get; set; }

    }
}
