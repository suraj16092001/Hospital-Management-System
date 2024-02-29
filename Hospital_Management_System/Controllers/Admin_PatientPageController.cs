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
using System.Collections.Generic;
using MySqlX.XDevAPI.Common;
using Google.Protobuf.Collections;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.Controllers
{
    public class Admin_PatientPageController : Controller
    {
        IAdmin_PatientPageBAL _IAdmin_PatientPageBAL;

        IEmailSenderBAL _EmailSender;
        public Admin_PatientPageController(IAdmin_PatientPageBAL admin_PatientPageBAL, IEmailSenderBAL emailSenderBAL)
        {
            _IAdmin_PatientPageBAL = admin_PatientPageBAL;
            _EmailSender = emailSenderBAL;
        }

        public IActionResult Admin_Patient()
        {
            return View();
        }

        public IActionResult PatientList()
        {
            Console.WriteLine(HttpContext.Session.GetString("role"));
            Console.WriteLine(HttpContext.Session.GetString("email"));
            Console.WriteLine(HttpContext.Session.GetString("password"));

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

            int? test = HttpContext.Session.GetInt32("id");
            oModel.User.created_by = test.Value;

            oModel.User.created_at = DateTime.Now;
            var result = _IAdmin_PatientPageBAL.AddPatient(oModel);
            if (result == "exists")
            {
                return Json(new { status = "warning", message = "Email Id Already Exists!" });
            }

            return Json(new { status = "success", message = "Patient add successfully!" });
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
        public IActionResult UpdatePatient([FromBody] PatientAllDataViewModel model)
        {
            int? test = HttpContext.Session.GetInt32("id");
            model.User.updated_by = test.Value;

            model.User.updated_at = DateTime.Now;
            var result = _IAdmin_PatientPageBAL.UpdatePatient(model);
            if (result == "exists")
            {
                return Json(new { status = "warning", message = "Email Id Already Exists!" });
            }

            return Json(new { status = "success", message = "Patient Update successfully!" });

        }



        [HttpPost]
        public IActionResult GetDoctors([FromBody] Admin_DoctorPageModel specialist)
        {
            List<UserModel> doctors = _IAdmin_PatientPageBAL.GetDoctors(specialist);
            return Json(doctors);

        }

        [HttpPost]
        public IActionResult AdminSidePatientAppointment([FromBody] Requested_AppointmentModel oModel)
        {
            int? test = HttpContext.Session.GetInt32("id");
            oModel.User = new UserModel();
            oModel.User.created_by = test.Value;
            oModel.User.created_at = DateTime.Now;
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


            var result = _IAdmin_PatientPageBAL.AdminSidePatientAppointment(oModel);
            //string test1="";
            //string test2=string.Empty;
            //if (test1 == test2)
            //if (result.Result == "exists")
            if (result.Result.Contains("exists"))
            {
                return Json(new { status = "warning", message = "Please select another slot!" });
            }
            return Json(new { status = "success", message = "Appointment Book Successfully!" });
        }

    }
}
