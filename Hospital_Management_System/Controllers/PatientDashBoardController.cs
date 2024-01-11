using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class PatientDashBoardController : Controller
    {
        public IActionResult PatientDashboard()
        {
            return View();
        }
    }
}
