using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text.Json;

namespace Hospital_Management_System.Controllers
{
    public class Admin_PatientPageController : Controller
    {
        IAdmin_PatientPageBAL _IAdmin_PatientPageBAL;

        public Admin_PatientPageController( IAdmin_PatientPageBAL admin_PatientPageBAL)
        {
            _IAdmin_PatientPageBAL = admin_PatientPageBAL;
        }

        public IActionResult Admin_Patient()
        {
            return View();
        }

        public IActionResult PatientList()
        {
            return Json(_IAdmin_PatientPageBAL.GetPatientList());
        }

        // view Create for Adding patient by admin
        public IActionResult AddPatient()
        {
            return View();
        }

        //Adding patient data in database
        [HttpPost]
        public IActionResult AddPatient(string model)
        {
            Admin_PatientPageModel admin_PatientPage = JsonSerializer.Deserialize<Admin_PatientPageModel>(model);
            _IAdmin_PatientPageBAL.AddPatient(admin_PatientPage);
            return Json("PatientList");
        }

        public IActionResult DeletePatient(int id)
        {
            _IAdmin_PatientPageBAL.DeletePatient(id);
            return RedirectToAction("PatientList");
        }

        public IActionResult GetPatientByID(int id)
        {
          return Json(_IAdmin_PatientPageBAL.GetPatientByID(id));
           
        }

        [HttpPost]
        public IActionResult UpdatePatient(string model,int Id)
        {
            Admin_PatientPageModel admin_PatientPage = JsonSerializer.Deserialize<Admin_PatientPageModel>(model);
            _IAdmin_PatientPageBAL.UpdatePatient(admin_PatientPage, Id);
            return Json("PatientList");
        }
    }
}
