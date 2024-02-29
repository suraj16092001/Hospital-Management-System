using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class PatientProfileController : Controller
    {
        IPatientProfileBAL _IPatientProfileBAL;
        public PatientProfileController(IPatientProfileBAL patientProfileBAL)
        {
            _IPatientProfileBAL = patientProfileBAL;
        }
        public IActionResult PatientProfile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPatient_Profile()
        {
            int? test = HttpContext.Session.GetInt32("id");
            int id = test.Value;
            return Json(_IPatientProfileBAL.GetPatient_Profile(id));
        }

        [HttpPost]
        public IActionResult UpdatePatient([FromBody] PatientAllDataViewModel model)
        {
            int? test = HttpContext.Session.GetInt32("id");
            model.User.id = test.Value;
            model.User.updated_by = test.Value;
            model.User.updated_at = DateTime.Now;
            var result = _IPatientProfileBAL.UpdatePatient(model);
            if (result == "exists")
            {
                return Json(new { status = "warning", message = "Email Id Already Exists!" });
            }
            return Json(new { status = "success", message = "Data Update successfully!" });

        }
    }
}
