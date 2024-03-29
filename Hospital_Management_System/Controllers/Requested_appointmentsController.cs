﻿using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class Requested_appointmentsController : Controller
    {
        IRequested_appointmentsBAL _IRequested_appointmentsBAL;
        IEmailSenderBAL _EmailSender;
        public Requested_appointmentsController(IRequested_appointmentsBAL requested_AppointmentsBAL,IEmailSenderBAL emailSender)
        {
            _IRequested_appointmentsBAL = requested_AppointmentsBAL;
            _EmailSender = emailSender;
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
        public async Task<IActionResult> UpdateStatus([FromBody] Requested_AppointmentModel oModel)
        {
            int? test = HttpContext.Session.GetInt32("id");
            oModel.User = new UserModel();
            oModel.User.updated_by = test.Value;

            oModel.User.updated_at = DateTime.Now;
            if (oModel.status_id == 1)
            {
                await _EmailSender.EmailSendAsync(oModel.email, "Appointment Requested", "Appointment Is requested,we will contact You soon");
            }
            else if (oModel.status_id == 2)
            {
                await _EmailSender.EmailSendAsync(oModel.email, "Appointment Confirm", "Congratulation Your Appointment Is confirmed!");
            }
            else if (oModel.status_id == 3)
            {
                await _EmailSender.EmailSendAsync(oModel.email, "Doctors Not Available", "Sorry For Inconvenience,For Some Reason Doctor Not Available!");
            }
            else if (oModel.status_id == 4)
            {
                await _EmailSender.EmailSendAsync(oModel.email, "Check Up Completed", "Check-up completed; your report will be sent to you soon.");

            }
            else if (oModel.status_id == 5)
            {
                await _EmailSender.EmailSendAsync(oModel.email, "Your Appointment is rescheduled", "Your appointment has been rescheduled. Please make a note of this change.");

            }
            _IRequested_appointmentsBAL.UpdateStatus(oModel);
            return Json("Status");
        }

        public IActionResult GetStatus()
        {
            List<Appointment_StatusModel> doctors = _IRequested_appointmentsBAL.GetStatus();
            return Json(doctors);
        }

        public IActionResult PopulateEmail(int id)
        {
            return Json(_IRequested_appointmentsBAL.PopulateEmail(id));
        }

    }
}
