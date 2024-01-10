using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class DoctorDashBoard : Controller
    {
        public IActionResult DoctorDashboard()
        {
            return View();
        }
    }
}
