using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            _IAdminPageBAL.AddAdmin(oModel);
            return Json("AdminList");
        }

        public IActionResult DeleteAdmin(int id)
        {
            _IAdminPageBAL.DeleteAdmin(id);
            return RedirectToAction("AdminList");
        }

        public IActionResult GetAdminByID(int id)
        {
            return Json(_IAdminPageBAL.GetAdminByID(id));

        }

        [HttpPost]
        public IActionResult UpdateAdmin(AdminAllDataViewModel model)
        {
            _IAdminPageBAL.UpdateAdmin(model);
            return Json("AdminList");
        }
    }
}
