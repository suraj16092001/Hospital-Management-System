﻿using Hospital_Management_System.HospitalBussinessManager.BAL;
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

            _IAdmin_PatientPageBAL.UpdatePatient(model);
            return Json("PatientList");
        }



        [HttpPost]
        public IActionResult GetDoctors([FromBody]Admin_DoctorPageModel specialist)
        {
            List<UserModel> doctors = _IAdmin_PatientPageBAL.GetDoctors(specialist);
            return Json(doctors);

        }

        [HttpPost]
        public IActionResult AdminSidePatientAppointment([FromBody] Requested_AppointmentModel oModel)
        {
            //DateTime appointmentDate = DateTime.ParseExact(oModel.appointment_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //TimeSpan appointmentTime = TimeSpan.Parse(oModel.appointment_time);

            //// Combine the date and time into one DateTime
            //DateTime appointmentDateTime = appointmentDate.Date + appointmentTime;

            //// Format the DateTime to MySQL format
            //oModel.appointment_date = appointmentDateTime.ToString("yyyy-MM-dd");
            //oModel.appointment_time = appointmentDateTime.ToString("HH:mm:ss");

            _IAdmin_PatientPageBAL.AdminSidePatientAppointment(oModel);
            return Json("Requested");
        }
    }
}
