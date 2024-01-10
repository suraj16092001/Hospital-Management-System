namespace Hospital_Management_System.Models
{
    public class LoginModel
    {
        public bool EmailExists { get; set; }
        public string GetPassword { get; set; }
        public string GetRole { get; set; }
        public string DbPassword { get; set; }
    }
}
