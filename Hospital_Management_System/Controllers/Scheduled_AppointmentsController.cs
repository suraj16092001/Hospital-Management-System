using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.Controllers
{
    public class Scheduled_AppointmentsController : Controller
    {
        IScheduled_AppointmentsBAL _IScheduled_AppointmentsBAL;
        public Scheduled_AppointmentsController(IScheduled_AppointmentsBAL iScheduled_Appointments)
        {

            _IScheduled_AppointmentsBAL = iScheduled_Appointments;

        }
        public IActionResult Scheduled_Appointments()
        {

            return View();
        }
        public IActionResult ScheduledPatientList(Requested_AppointmentModel model)
        {
            int? test = HttpContext.Session.GetInt32("id");
            model.doctor_id = test.Value;
            return Json(_IScheduled_AppointmentsBAL.ScheduledPatientList(model));
        }


    }
}
