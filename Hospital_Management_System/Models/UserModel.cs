using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class UserModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Username must contain only letters and numbers.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]

        public string email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+-={}?|:]).{8,32}$",
        //    ErrorMessage = "Please Enter Valid Password.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please re-enter your password.")]
        public string confirm_password { get; set; }
    }
}
