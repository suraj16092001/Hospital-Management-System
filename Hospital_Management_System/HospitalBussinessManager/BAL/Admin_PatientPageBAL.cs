using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Admin_PatientPageBAL : IAdmin_PatientPageBAL
    {
        IAdmin_PatientPageDAL _IAdmin_PatientPageDAL;
        ILoginDAL _ILoginDAL;
        IPatientDashBoardDAL _IPatientDashBoardDAL;
        IEmailSenderBAL _EmailSender;
        public Admin_PatientPageBAL(IDBManager dBManager, IEmailSenderBAL emailSender)
        {
            _IAdmin_PatientPageDAL = new Admin_PatientPageDAL(dBManager);
            _ILoginDAL = new LoginDAL(dBManager);
            _IPatientDashBoardDAL = new PatientDashBoardDAL(dBManager);
            _EmailSender = emailSender;
        }

        List<PatientAllDataViewModel> IAdmin_PatientPageBAL.GetPatientList()
        {
            return _IAdmin_PatientPageDAL.GetPatientList();
        }

        public string AddPatient(PatientAllDataViewModel oModel)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(oModel.User.email, oModel.User.id);

            if (emailExists)
            {
                return "exists";
            }
            oModel.User.role = 2;
            _IAdmin_PatientPageDAL.AddPatient(oModel);
            return "success";
        }

        public PatientAllDataViewModel GetPatientByID(int id)
        {
            return _IAdmin_PatientPageDAL.GetPatientByID(id);
        }

        public string UpdatePatient(PatientAllDataViewModel model)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(model.User.email, model.User.id);

            if (emailExists)
            {
                return "exists";
            }
             _IAdmin_PatientPageDAL.UpdatePatient(model);
            return "success";
        }

        public void DeletePatient(UserModel model, int id)
        {
            _IAdmin_PatientPageDAL.DeletePatient(model,id);

        }

        public List<UserModel> GetDoctors(Admin_DoctorPageModel specialist)
        {
            return _IAdmin_PatientPageDAL.GetDoctors(specialist);
        }

        public async Task<string> AdminSidePatientAppointment(Requested_AppointmentModel oModel)
        {
            bool TimeDateExists = _IAdmin_PatientPageDAL.CheckDateTimeOfDoctorsAvailability(oModel);
            if (TimeDateExists)
            {
                return "exists";
            }
            oModel.status_id = 2;

           
            if (oModel.status_id == 2)
            {
                await _EmailSender.EmailSendAsync(oModel.email, "Appointment Confirm", "Congratulation Your Appointment Is confirmed!");
            }
            
            _IPatientDashBoardDAL.RequestedPatientAppointment(oModel);
            return "success";
        }
    }
}
