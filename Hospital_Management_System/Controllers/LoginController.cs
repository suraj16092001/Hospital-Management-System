using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web;
using System.Text.Json;
using MySqlX.XDevAPI.Common;

namespace Hospital_Management_System.Controllers 
{ 
    
    public class LoginController : Controller
    {
        readonly ILoginBAL _ILoginBAL;
        public LoginController(ILoginBAL loginBAL)
        {
            _ILoginBAL = loginBAL;
        }

        public IActionResult GetUser()
        {
            return Json(_ILoginBAL.UserList());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPost(string email,string password)
        {
            var result =_ILoginBAL.LoginPost(email,password);
            if(result== "Valid")
            {
                return Json("Valid");
            }
            return Json("Invalid Credential!");
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpPost(string model)
        {
            UserModel user = JsonSerializer.Deserialize<UserModel>(model)!;
            if (ModelState.IsValid)
            {
                var result = _ILoginBAL.SignUp(user);

                if (result == "exists")
                {
                    return Json( new { status = "warning", message = "Email Id Already Exists!" });
                }
                return Json(new { status = "success", message = "User register successfully!" });
            }

            return View();
            
        }
    }
        
}
