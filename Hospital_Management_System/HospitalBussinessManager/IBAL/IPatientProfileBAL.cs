using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IPatientProfileBAL
    {
        public PatientAllDataViewModel GetPatient_Profile(int id);

        public string UpdatePatient(PatientAllDataViewModel model);
    }
}
