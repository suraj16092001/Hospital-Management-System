using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Hospital_Management_System.Controllers
{
    public class DoctorDashBoardController : Controller
    {
       
        public IActionResult DoctorDashboard()
        {
            Console.WriteLine(HttpContext.Session.GetInt32("id"));
            return View();
        }
    }
}
