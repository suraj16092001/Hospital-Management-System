using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class AdminDashBoardController : Controller
    {
        //[Authorize(Roles ="Admin")]
        public IActionResult AdminDashBoard()
        {
            Console.WriteLine(HttpContext.Session.GetInt32("id"));
            return View();
        }

     
    }
}
