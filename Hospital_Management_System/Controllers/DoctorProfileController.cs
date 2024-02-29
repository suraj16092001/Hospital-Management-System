using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hospital_Management_System.Controllers
{
    public class DoctorProfileController : Controller
    {
        IDoctorProfileBAL _IDoctorProfileBAL;
        public DoctorProfileController(IDoctorProfileBAL doctorProfile)
        {
            _IDoctorProfileBAL = doctorProfile;
        }
        public IActionResult Doctor_Profile()
        {
            return View();
        }

        public IActionResult GetDoctor_Profile()
        {
            int? test = HttpContext.Session.GetInt32("id");
            int id = test.Value;
            return Json(_IDoctorProfileBAL.GetDoctor_Profile(id));

        }
        [HttpPost]
        public IActionResult UpdateDoctor(string model, int Id, IFormFile file)
        {
            int? test = HttpContext.Session.GetInt32("id");
            Id = test.Value;
            DoctorAllDataViewModel doctor = JsonSerializer.Deserialize<DoctorAllDataViewModel>(model)!;
            doctor.User.updated_by = test.Value;
            doctor.User.updated_at = DateTime.Now;
            var result = _IDoctorProfileBAL.UpdateDoctor(doctor, Id, file);


            if (result == "exists")
            {
                return Json(new { status = "warning", message = "Email Id Already Exists!" });
            }


            return Json(new { status = "success", message = "Data Update successfully!" });
        }

    }
}
