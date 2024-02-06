using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class Requested_appointmentsController : Controller
    {
        IRequested_appointmentsBAL _IRequested_appointmentsBAL;
        public Requested_appointmentsController(IRequested_appointmentsBAL requested_AppointmentsBAL)
        {
            _IRequested_appointmentsBAL = requested_AppointmentsBAL;
        }
        public IActionResult Request_appointments()
        {
            return View();
        }

        public IActionResult RequestedPatientList()
        {
            return Json(_IRequested_appointmentsBAL.RequestedPatientList());
        }

        //populate requested data on admin side 
        public IActionResult GetRequested_Appointment(int id)
        {
            return Json(_IRequested_appointmentsBAL.GetRequested_Appointment(id));
        }

        //update status 
        [HttpPost]
        public IActionResult UpdateStatus([FromBody] Requested_AppointmentModel oModel)
        {
            _IRequested_appointmentsBAL.UpdateStatus(oModel);
            return Json("Status");
        }
    }
}
