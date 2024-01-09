using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class AdminDashBoardController : Controller
    {
        
        public IActionResult AdminDashBoard()
        {
            return View();
        }
    }
}
