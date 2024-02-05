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
        public IActionResult RequestedAppointment([FromBody]RequestedCombinedViewModel oModel)
        {
            DateTime appointmentDate = DateTime.ParseExact(oModel.Appointment.appointment_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            TimeSpan appointmentTime = TimeSpan.Parse(oModel.Appointment.appointment_time);

            // Combine the date and time into one DateTime
            DateTime appointmentDateTime = appointmentDate.Date + appointmentTime;

            // Format the DateTime to MySQL format
            oModel.Appointment.appointment_date = appointmentDateTime.ToString("yyyy-MM-dd");
            oModel.Appointment.appointment_time = appointmentDateTime.ToString("HH:mm:ss");

            _IPatientDashBoardBAL.RequestedAppointment(oModel);
            return View();
        }


    }
}
