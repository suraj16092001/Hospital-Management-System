using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web;

namespace Hospital_Management_System.Controllers.User
{
    public class UserController : Controller
    {
     
        public readonly IConfiguration  _configuration;
        public string connectionString;
        public UserController(IConfiguration configuration)
        {
            _configuration =configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult AdminDashBoard()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email,string Password ,UserModel omodel)
        {
          
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                const string Query = "Select email,pass from loginUser where email=@email and pass=@password;";
                using (MySqlCommand command =  new MySqlCommand(Query,connection)) 
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@email", Email);
                    command.Parameters.AddWithValue("@password", Password);
                    command.ExecuteNonQuery();
  
                }
                if (omodel.email == Email && omodel.password == Password)
                {
                    return RedirectToAction("AdminDashBoard");
                }
                else
                {
                    ViewData["Message"] = "User Login Details failed!";
                    return View();
                }
            }
            
        }
    
        public IActionResult SignUp() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                const string Query = "insert into loginUser (name,email,pass) values (@name,@email,@pass);";
                using (MySqlCommand command = new MySqlCommand(Query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@pass", model.password);
                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Login");
        }
    }
        
}
