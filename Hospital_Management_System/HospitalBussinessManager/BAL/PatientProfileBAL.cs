using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class PatientProfileBAL : IPatientProfileBAL
    {
        IPatientProfileDAL _IPatientProfileDAL;
        ILoginDAL _ILoginDAL;
        public PatientProfileBAL(IDBManager dBManager)
        {
            _IPatientProfileDAL = new PatientProfileDAL (dBManager);
            _ILoginDAL = new LoginDAL (dBManager);
        }
        public PatientAllDataViewModel GetPatient_Profile(int id)
        {
            return _IPatientProfileDAL.GetPatient_Profile(id);
        }

        public string UpdatePatient(PatientAllDataViewModel model)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(model.User.email, model.User.id);

            if (emailExists)
            {
                return "exists";
            }

            _IPatientProfileDAL.UpdatePatient(model);
            return "success";

        }
    }
}
