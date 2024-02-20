using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.Controllers
{
    public class DoctorDashBoardController : Controller
    {
       
        public IActionResult DoctorDashboard()
        {
            Console.WriteLine(HttpContext.Session.GetInt32("id"));
            return View();
        }

        //public IActionResult GetProfileImageBySessionID()
        //{
        //    int? test = HttpContext.Session.GetInt32("id");

        //}
    }
}
