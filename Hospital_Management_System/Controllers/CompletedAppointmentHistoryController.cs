using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class CompletedAppointmentHistoryController : Controller
    {
        IRequested_appointmentsBAL _IRequested_appointmentsBAL;
        public CompletedAppointmentHistoryController(IRequested_appointmentsBAL requested_AppointmentsBAL)
        {
            _IRequested_appointmentsBAL= requested_AppointmentsBAL;
        }
        public IActionResult CompletedAppointmentHistory()
        {
            return View();
        }

        public IActionResult CompletedPatientList()
        {
            return Json(_IRequested_appointmentsBAL.RequestedPatientList());
        }

        public IActionResult GetCompleted_Appointment(int id)
        {
            return Json(_IRequested_appointmentsBAL.GetRequested_Appointment(id));
        }
    }
}
