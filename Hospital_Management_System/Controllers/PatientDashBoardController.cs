using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Globalization;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

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
        public IActionResult RequestedAppointment([FromBody] Requested_AppointmentModel oModel)
        {
            oModel.User = new UserModel();
            int? test = HttpContext.Session.GetInt32("id");
            oModel.patient_id = test.Value;

            oModel.User.created_at = DateTime.Now;
            oModel.User.created_by = test.Value;

            DateTime appointmentDate = DateTime.ParseExact(oModel.appointment_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // Parse the time of day string into a DateTime object
            DateTime appointmentTimeDateTime = DateTime.ParseExact(oModel.appointment_time, "h:mm tt", CultureInfo.InvariantCulture);
            // Extract the TimeSpan from the DateTime object
            TimeSpan appointmentTime = appointmentTimeDateTime.TimeOfDay;

            // Combine the date and time into one DateTime
            DateTime appointmentDateTime = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentTime.Hours, appointmentTime.Minutes, appointmentTime.Seconds);

            // Format the DateTime to MySQL format
            oModel.appointment_date = appointmentDateTime.ToString("yyyy-MM-dd");
            oModel.appointment_time = appointmentDateTime.ToString("HH:mm:ss");

            var result=_IPatientDashBoardBAL.RequestedAppointment(oModel);

            if (result.Result.Contains("exists"))
            {
                return Json(new { status = "warning", message = "Please select another slot!" });
            }
            return Json(new { status = "success", message = "Your appointment request has been sent we will contact you soon" });
        }

        public IActionResult PopulateEmailandName(int id)
        {
            int? test = HttpContext.Session.GetInt32("id");
            id = test.Value;
            return Json(_IPatientDashBoardBAL.PopulateEmailandName(id));
        }

    }
}
