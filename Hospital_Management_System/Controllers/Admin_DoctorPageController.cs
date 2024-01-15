using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hospital_Management_System.Controllers
{
    public class Admin_DoctorPageController: Controller
    {
        IAdmin_DoctorPageBAL _IAdmin_DoctorPageBAL;

        public Admin_DoctorPageController(IAdmin_DoctorPageBAL admin_DoctorPageBAL)
        {
            _IAdmin_DoctorPageBAL= admin_DoctorPageBAL;
        }
        public IActionResult Admin_Doctor()
        {
            return View();
        }

        public IActionResult DoctorList()
        {
            return Json(_IAdmin_DoctorPageBAL.GetDoctorList());
        }

        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDoctor(string model)
        {
            Admin_DoctorPageModel admin_DoctorPage = JsonSerializer.Deserialize<Admin_DoctorPageModel>(model);
            _IAdmin_DoctorPageBAL.AddDoctor(admin_DoctorPage);
            return Json("DoctorList");
        }

        public IActionResult DeleteDoctor(int id)
        {
             _IAdmin_DoctorPageBAL.DeleteDoctor(id);
            return RedirectToAction("DoctorList");
        }

        public  IActionResult GetDoctorByID(int id)
        {
            return Json(_IAdmin_DoctorPageBAL.GetDoctorByID(id));
           
        }
    }
}
