using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hospital_Management_System.Controllers
{
    public class Admin_DoctorPageController : Controller
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
        public IActionResult AddDoctor(string model, IFormFile file)
        {

           
                DoctorAllDataViewModel doctor = JsonSerializer.Deserialize<DoctorAllDataViewModel>(model)!;
                var result = _IAdmin_DoctorPageBAL.AddDoctor(doctor, file);

                if (result == "exists")
                {
                    return Json(new { status = "warning", message = "Email Id Already Exists!" });
                }

                return Json(new { status = "success", message = "Doctor add successfully!" });
            
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

        [HttpPost]
        public IActionResult UpdateDoctor(string model, int Id, IFormFile file)
        {
            
            DoctorAllDataViewModel doctor = JsonSerializer.Deserialize<DoctorAllDataViewModel>(model)!;
               
            var result = _IAdmin_DoctorPageBAL.UpdateDoctor(doctor, Id, file);


            if (result == "exists")
            {
                return Json(new { status = "warning", message = "Email Id Already Exists!" });
            }


            return Json(new { status = "success", message = "Doctor Update successfully!" });
        }

    }
}
