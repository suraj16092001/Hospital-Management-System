using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult ScheduledPatientList()
        {
            return Json(_IScheduled_AppointmentsBAL.ScheduledPatientList());
        }
    }
}
