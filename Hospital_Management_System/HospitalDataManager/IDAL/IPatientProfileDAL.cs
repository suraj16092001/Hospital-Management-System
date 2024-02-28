using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IPatientProfileDAL
    {
        public PatientAllDataViewModel GetPatient_Profile(int id);
        public PatientAllDataViewModel UpdatePatient(PatientAllDataViewModel patient);
    }
}
