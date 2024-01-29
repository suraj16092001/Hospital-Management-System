using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class AdminPageModel
    {
        public int id { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/DD/YYYY}")]
		public string DateOfBirth { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }

        public string address { get; set; }
		public int register_id { get; set; }
	}
}
