using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.Controllers
{
    public class Scheduled_AppointmentsController : Controller
    {
        IScheduled_AppointmentsBAL _IScheduled_AppointmentsBAL;
        IEmailSenderBAL _EmailSender;
        public Scheduled_AppointmentsController(IScheduled_AppointmentsBAL iScheduled_Appointments, IEmailSenderBAL emailSender)
        {

            _IScheduled_AppointmentsBAL = iScheduled_Appointments;

            _EmailSender = emailSender;
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

        public IActionResult GetScheduledAppointments(int id)
        {
            return Json(_IScheduled_AppointmentsBAL.GetScheduledAppointments(id));
        }

        public IActionResult GetStatusForDoctor()
        {
            List<Appointment_StatusModel> doctors = _IScheduled_AppointmentsBAL.GetStatusForDoctor();
            return Json(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatusByEmailFromDoctor([FromBody] Requested_AppointmentModel oModel)
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
            _IScheduled_AppointmentsBAL.UpdateStatusByEmailFromDoctor(oModel);
            return Json("Status");
        }
    }
}
