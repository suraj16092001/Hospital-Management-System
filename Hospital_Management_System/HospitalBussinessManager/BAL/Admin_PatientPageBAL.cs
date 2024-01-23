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

        List<Admin_PatientPageModel> IAdmin_PatientPageBAL.GetPatientList()
        {
            return _IAdmin_PatientPageDAL.GetPatientList();
        }

        public PatientAllDataViewModel AddPatient(PatientAllDataViewModel oModel)
        {
            oModel.User.role = 2;
            return _IAdmin_PatientPageDAL.AddPatient(oModel);
        }

        public Admin_PatientPageModel GetPatientByID(int id)
        {
            return _IAdmin_PatientPageDAL.GetPatientByID(id);
        }

        public string UpdatePatient(Admin_PatientPageModel model, int Id)
        {
            _IAdmin_PatientPageDAL.UpdatePatient(model, Id);
            return "Success";
        }

        public void DeletePatient(int id)
        {
            _IAdmin_PatientPageDAL.DeletePatient(id);

        }

        public AppointmentModel BookAppointment(AppointmentModel model)
        {
            return _IAdmin_PatientPageDAL.BookAppointment(model);
        }
    }
}
