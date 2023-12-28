using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult AdminDashBoard()
        {
            return View();
        }
    }
}
