namespace Hospital_Management_System.Models
{
    public class Admin_DoctorPageModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string qualification { get; set; }
        public string specialist { get; set; }
        public string gender  { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string DateOfBirth { get; set; } // age instead dob
        public string address { get; set; }
    }   
}
