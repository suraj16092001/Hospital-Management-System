using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class AdminProfileController : Controller
    {
        IAdminProfileBAL _IAdminProfileBAL;
        public AdminProfileController(IAdminProfileBAL adminProfile)
        {
            _IAdminProfileBAL = adminProfile;
        }
        public IActionResult Admin_Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAdmin_Profile()
        {
            int? test = HttpContext.Session.GetInt32("id");
            int id = test.Value;
            return  Json(_IAdminProfileBAL.GetAdmin_Profile(id));
        }


        [HttpPost]
        public IActionResult UpdateAdmin([FromBody] AdminAllDataViewModel model)
        {
            int? test = HttpContext.Session.GetInt32("id");
             model.User.id = test.Value;
            model.User.updated_by = test.Value;
            model.User.updated_at= DateTime.Now;

            var result = _IAdminProfileBAL.UpdateAdmin(model);
            if (result == "exists")
            {
                return Json(new { status = "warning", message = "Email Id Already Exists!" });
            }
            return Json(new { status = "success", message = "Data Update successfully!" });


        }
    }
}
