using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class Admin_PatientPage : Controller
    {
        //IAdmin_PatientPageBAL _IAdmin_PatientPage;
        //public Admin_PatientPage(IAdmin_PatientPageBAL admin_PatientPage)
        //{
        //    _IAdmin_PatientPage = admin_PatientPage;    
        //}
        public IActionResult Admin_Patient()
        {
            return View();
        }

        public IActionResult AddPatient()
        {
            return View();
        }

        public IActionResult AddPatient(string model)
        {
            //admin_patientpage patient= 
            return Json("index");
        }
    }
}
