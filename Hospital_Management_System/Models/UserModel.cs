﻿using Hospital_Management_System.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class UserModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression(@"^[0-9a-zA-Z]+[+._-]{0,1}[0-9a-zA-Z]+[@][a-zA-Z0-9]+[.][a-zA-Z]{2,3}([.][a-zA-Z]{2,3}){0,1}$",
        ErrorMessage = "Please Insert Valid Email.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+-={}?|:]).{8,32}$",
        ErrorMessage = "Please Enter Valid Password.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please re-enter your password.")]
        [Compare(nameof(password), ErrorMessage = "Passwords do not match")]
        public string confirm_password { get; set; }


        [Required]

        public int role { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; } 
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public int deleted_by { get; set; } 
        public DateTime? deleted_at { get; set; }
        public int isDeleted { get; set; }
    }
}
