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

        public Admin_PatientPageBAL(IDBManager dBManager)
        {
            _IAdmin_PatientPageDAL = new Admin_PatientPageDAL(dBManager);

        }

        List<UserModel> IAdmin_PatientPageBAL.GetPatientList()
        {
            return _IAdmin_PatientPageDAL.GetPatientList();
        }

        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel model)
        {
            return _IAdmin_PatientPageDAL.AddPatient(model);
        }
        public UserModel GetPatientByID(int id)
        {
            return _IAdmin_PatientPageDAL.GetPatientByID(id);
        }

        public string UpdatePatient(UserModel model, int Id)
        {
            bool emailExists = _IAdmin_PatientPageDAL.CheckEmailExistence(model.email);
            if (emailExists)
            {
                return "exists";
            }
            _IAdmin_PatientPageDAL.UpdatePatient(model, Id);
            return "Success";
        }

        public void DeletePatient(int id)
        {
            _IAdmin_PatientPageDAL.DeletePatient(id);
            
        }

        public string RegisterPatient(UserModel user)
        {
            bool emailExists = _IAdmin_PatientPageDAL.CheckEmailExistence(user.email);

            if (emailExists)
            {
                return "exists";
            }

            _IAdmin_PatientPageDAL.RegisterPatient(user);

            return "success";
        }

    }
}
