using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class PatientDashBoardBAL : IPatientDashBoardBAL
    {
        IPatientDashBoardDAL _IPatientDashBoardDAL;
        IAdmin_PatientPageDAL _IAdmin_PatientPageDAL;
        IEmailSenderBAL _EmailSender;
        
        public PatientDashBoardBAL(IDBManager dBManager, IEmailSenderBAL emailSender)
        {
            _IPatientDashBoardDAL = new PatientDashBoardDAL(dBManager);
            _IAdmin_PatientPageDAL = new Admin_PatientPageDAL(dBManager);
           
            _EmailSender = emailSender;
        }

        public async Task<string> RequestedAppointment(Requested_AppointmentModel model)
        {
            model.status_id = 1;
            bool TimeDateExists = _IAdmin_PatientPageDAL.CheckDateTimeOfDoctorsAvailability(model);
            if (TimeDateExists)
            {
                return "exists";
            }
           
            if (model.status_id == 1)
            {
                await _EmailSender.EmailSendAsync(model.email, "Appointment Requested", "Appointment Is requested,we will contact You soon");
            }
            _IPatientDashBoardDAL.RequestedPatientAppointment(model);
            return "success";
        }
        public Requested_AppointmentModel PopulateEmailandName(int id)
        {
            return _IPatientDashBoardDAL.PopulateEmailandName(id);
        }
    }
}
