using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.Controllers
{
    public class AdminPageController : Controller
    {
        IAdminPageBAL _IAdminPageBAL;
        public AdminPageController(IAdminPageBAL adminPageBAL)
        {
            _IAdminPageBAL = adminPageBAL;
        }
        public IActionResult AdminPage()
        {
            return View();
        }

        public IActionResult AdminList()
        {
            return Json(_IAdminPageBAL.GetAdminList());
        }

        public IActionResult AddAdmin() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin([FromBody] AdminAllDataViewModel oModel)
        {
            int? test = HttpContext.Session.GetInt32("id");
            oModel.User.created_by = test.Value;
            oModel.User.created_at = DateTime.Now;
            var result = _IAdminPageBAL.AddAdmin(oModel);
            if (result == "exists")
            {
                return Json(new { status = "warning", message = "Email Id Already Exists!" });
            }
            return Json(new { status = "success", message = "Admin add successfully!" });
      
        }

        public IActionResult DeleteAdmin(int id)
        {
            UserModel model = new UserModel();
            model.deleted_at = DateTime.Now;
            int? test = HttpContext.Session.GetInt32("id");
            model.deleted_by = test.Value;
            _IAdminPageBAL.DeleteAdmin(model,id);
            return RedirectToAction("AdminList");
        }

        public IActionResult GetAdminByID(int id)
        {
            return Json(_IAdminPageBAL.GetAdminByID(id));

        }

        [HttpPost]
        public IActionResult UpdateAdmin([FromBody] AdminAllDataViewModel model)
        {
            int? test = HttpContext.Session.GetInt32("id");
            model.User.updated_by = test.Value;

            model.User.updated_at = DateTime.Now;
            var result = _IAdminPageBAL.UpdateAdmin(model);
            if (result == "exists")
            {
                return Json(new { status = "warning", message = "Email Id Already Exists!" });
            }
            return Json(new { status = "success", message = "Admin Update successfully!" });
        }
    }
}
