using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.Controllers
{
    public class DoctorDashBoardController : Controller
    {
        IDoctorDashBoardBAL _IDoctorDashBoardBAL;
        public DoctorDashBoardController(IDoctorDashBoardBAL iDoctorDashBoardBAL)
        {

            _IDoctorDashBoardBAL = iDoctorDashBoardBAL;

        }
        public IActionResult DoctorDashboard()
        {
            Console.WriteLine(HttpContext.Session.GetInt32("id"));
            return View();
        }

        [HttpGet]
        public IActionResult PopulateCount(AdminAllDataViewModel Model)
        {
            int? test = HttpContext.Session.GetInt32("id");
            Model.id = test.Value;
            return Json(_IDoctorDashBoardBAL.PopulateCount(Model));
        }
    }
}
