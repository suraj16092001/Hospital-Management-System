using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class UserModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address format.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one number, and one special character.")]
        public string email { get; set; }

        public string password { get; set; }
    }
}
