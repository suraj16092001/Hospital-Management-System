using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Scheduled_AppointmentsBAL : IScheduled_AppointmentsBAL
    {
        IScheduled_AppointmentsDAL _IScheduled_AppointmentsDAL;
        IEmailSenderBAL _EmailSender;
        public Scheduled_AppointmentsBAL(IDBManager dBManager, IEmailSenderBAL emailSender)
        {
            _IScheduled_AppointmentsDAL = new Scheduled_AppointmentsDAL(dBManager);
            _EmailSender = emailSender;
        }

        public List<Requested_AppointmentModel> ScheduledPatientList(Requested_AppointmentModel model)
        {
                return _IScheduled_AppointmentsDAL.ScheduledPatientList(model);
        }

        public Requested_AppointmentModel GetScheduledAppointments(int id)
        {
            return _IScheduled_AppointmentsDAL.GetScheduledAppointments(id);
        }

        public List<Appointment_StatusModel> GetStatusForDoctor()
        {
            return _IScheduled_AppointmentsDAL.GetStatusForDoctor();

        }

        public async Task<string> UpdateStatusByEmailFromDoctor(Requested_AppointmentModel model)
        {
            if (model.status_id == 4)
            {
                await _EmailSender.EmailSendAsync(model.email, "Check Up Completed", "Check-up completed; your report will be sent to you soon.");

            }
            else if (model.status_id == 5)
            {
                await _EmailSender.EmailSendAsync(model.email, "Your Appointment is rescheduled", "Your appointment has been rescheduled. Please make a note of this change.");

            }
            return "doctorstatus";
        }
    }
}
