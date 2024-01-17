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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

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
        public IActionResult LoginPost(string email, string password)
        {
            LoginModel login = new LoginModel();
            
            if (ModelState.IsValid)
            {
               login = _ILoginBAL.LoginPost(email, password);

                if (!login.EmailExists)
                {
                    return Json(new { status = "warning", message = "Email doesn't exists." });
                }
                else if (login.GetPassword != login.DbPassword)
                {
                    return Json(new { status = "warning", message = "Invalid Password" });
                }
            }
            //if (login != null)
            //{
            //    HttpContext.Session.SetString("role", login.GetRole);
            //    HttpContext.Session.SetString("email", email);
            //    HttpContext.Session.SetString("password", password);
            //}
            //else
            //{
            //    ViewBag.Message = "Login failed";
            //    return View();
            //}
            return Json(new { role=login.GetRole , status = "success", message = "login successfully!" });
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpPost(string model)
        {
            //UserModel user = JsonSerializer.Deserialize<UserModel>(model)!;
            UserModel user = JsonConvert.DeserializeObject<UserModel>(model)!;
            if (ModelState.IsValid)
            {
                var result = _ILoginBAL.SignUp(user);

                if (result == "exists")
                {
                    return Json(new { status = "warning", message = "Email Id Already Exists!" });
                }
                return Json(new { status = "success", message = "User register successfully!" });
            }

            return View();

        }
    }

}
