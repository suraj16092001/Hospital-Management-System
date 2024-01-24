using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text.Json;

namespace Hospital_Management_System.Controllers
{
    public class Admin_PatientPageController : Controller
    {
        IAdmin_PatientPageBAL _IAdmin_PatientPageBAL;


        public Admin_PatientPageController(IAdmin_PatientPageBAL admin_PatientPageBAL)
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
        public IActionResult AddPatientDetails([FromBody] PatientAllDataViewModel oModel)
        {
            _IAdmin_PatientPageBAL.AddPatient(oModel);
            return Json("PatientList");
        }

        public IActionResult DeletePatient(int id)
        {
            _IAdmin_PatientPageBAL.DeletePatient(id);
            return Json("PatientList");
        }

        public IActionResult GetPatientByID(int id)
        {
            return Json(_IAdmin_PatientPageBAL.GetPatientByID(id));
        }

        [HttpPost]
        public IActionResult UpdatePatient(string model, int Id)
        {
            PatientAllDataViewModel admin_PatientPage = JsonConvert.DeserializeObject<PatientAllDataViewModel>(model);
            _IAdmin_PatientPageBAL.UpdatePatient(admin_PatientPage, Id);
            return Json("PatientList");
        }

        [HttpPost]
        public IActionResult BookAppointment(AppointmentModel model)
        {
            // Parse the date and time strings into DateTime
            DateTime appointmentDate = DateTime.ParseExact(model.appointment_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            TimeSpan appointmentTime = TimeSpan.Parse(model.appointment_time);

            // Combine the date and time into one DateTime
            DateTime appointmentDateTime = appointmentDate.Date + appointmentTime;

            // Format the DateTime to MySQL format
            model.appointment_date = appointmentDateTime.ToString("yyyy-MM-dd");
            model.appointment_time = appointmentDateTime.ToString("HH:mm:ss");

            _IAdmin_PatientPageBAL.BookAppointment(model);

            return Json("PatientList");
        }

    }
}
