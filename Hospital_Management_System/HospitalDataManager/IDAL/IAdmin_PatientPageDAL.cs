using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdmin_PatientPageDAL
    {
        public List<PatientAllDataViewModel> GetPatientList();
        public PatientAllDataViewModel AddPatient(PatientAllDataViewModel oModel);

        public PatientAllDataViewModel GetPatientByID(int id);
        public PatientAllDataViewModel UpdatePatient(PatientAllDataViewModel patient, int Id);
        public void DeletePatient(int id);
        public AppointmentModel BookAppointment(AppointmentModel appointment);
    }
}
