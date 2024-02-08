using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Admin_PatientPageBAL:IAdmin_PatientPageBAL
    {
        IAdmin_PatientPageDAL _IAdmin_PatientPageDAL;
        ILoginDAL _ILoginDAL;

        public Admin_PatientPageBAL(IDBManager dBManager)
        {
            _IAdmin_PatientPageDAL = new Admin_PatientPageDAL(dBManager);
            _ILoginDAL= new LoginDAL(dBManager);

        }

        List<PatientAllDataViewModel> IAdmin_PatientPageBAL.GetPatientList()
        {
            return _IAdmin_PatientPageDAL.GetPatientList();
        }

        public string AddPatient(PatientAllDataViewModel oModel)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(oModel.User.email);

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

       public PatientAllDataViewModel UpdatePatient(PatientAllDataViewModel model)
        {
            return _IAdmin_PatientPageDAL.UpdatePatient(model); ;
        }

        public void DeletePatient(int id)
        {
            _IAdmin_PatientPageDAL.DeletePatient(id);

        }

        public AppointmentModel BookAppointment(AppointmentModel model)
        {
            return _IAdmin_PatientPageDAL.BookAppointment(model);
        }

        public List<UserModel> GetDoctors(Admin_DoctorPageModel specialist)
        {
            return _IAdmin_PatientPageDAL.GetDoctors(specialist);
        }
    }
}
