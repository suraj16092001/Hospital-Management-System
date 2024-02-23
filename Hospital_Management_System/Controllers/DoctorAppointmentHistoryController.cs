using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class DoctorAppointmentHistoryController : Controller
    {
        IDoctorAppointmentHistoryBAL _IDoctorAppointmentHistoryBAL;
        public DoctorAppointmentHistoryController(IDoctorAppointmentHistoryBAL doctorAppointmentHistoryBAL)
        {
            _IDoctorAppointmentHistoryBAL = doctorAppointmentHistoryBAL;
        }
        public IActionResult DoctorAppointmentHistory()
        {
            return View();
        }

        public IActionResult DoctorAppointmentHistoryList(Requested_AppointmentModel model)
        {
            int? test = HttpContext.Session.GetInt32("id");
            model.doctor_id = test.Value;
            return Json(_IDoctorAppointmentHistoryBAL.PastAppointmentPatientList(model));
        }
    }
}
