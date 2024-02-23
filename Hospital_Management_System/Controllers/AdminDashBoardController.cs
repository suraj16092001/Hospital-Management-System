using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class AdminDashBoardController : Controller
    {
        IAdminDashBoardBAL _IAdminDashBoardBAL;
        public AdminDashBoardController(IAdminDashBoardBAL adminDashBoard)
        {
            _IAdminDashBoardBAL = adminDashBoard;
        }
        //[Authorize(Roles ="Admin")]
        public IActionResult AdminDashBoard()
        {
            Console.WriteLine(HttpContext.Session.GetInt32("id"));
            return View();
        }

        [HttpGet]
        public IActionResult PopulateCount()
        {
            return Json(_IAdminDashBoardBAL.PopulateCount());
        }

    }
}
