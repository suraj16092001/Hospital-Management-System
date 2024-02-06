using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Hospital_Management_System.Controllers
{
    public class PatientDashBoardController : Controller
    {
        IPatientDashBoardBAL _IPatientDashBoardBAL;
        public PatientDashBoardController(IPatientDashBoardBAL patientDashBoardBAL)
        {
            _IPatientDashBoardBAL = patientDashBoardBAL;
        }
        public IActionResult PatientDashBoard()
        {
            Console.WriteLine(HttpContext.Session.GetInt32("id"));
            return View();
        }

        [HttpPost]
        public IActionResult RequestedAppointment([FromBody]Requested_AppointmentModel oModel)
        {
            int? test = HttpContext.Session.GetInt32("id");
            oModel.patient_id = test.Value;
            DateTime appointmentDate = DateTime.ParseExact(oModel.appointment_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            TimeSpan appointmentTime = TimeSpan.Parse(oModel.appointment_time);

            // Combine the date and time into one DateTime
            DateTime appointmentDateTime = appointmentDate.Date + appointmentTime;

            // Format the DateTime to MySQL format
            oModel.appointment_date = appointmentDateTime.ToString("yyyy-MM-dd");
            oModel.appointment_time = appointmentDateTime.ToString("HH:mm:ss");

            _IPatientDashBoardBAL.RequestedAppointment(oModel);
            return Json("Requested");
        }


    }
}
