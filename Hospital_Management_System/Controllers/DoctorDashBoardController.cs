using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class DoctorDashBoardController : Controller
    {
        public IActionResult DoctorDashboard()
        {
            return View();
        }
    }
}
