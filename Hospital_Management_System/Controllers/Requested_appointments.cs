using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class Requested_appointments : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Request_appointments()
        {
            return View();
        }
    }
}
