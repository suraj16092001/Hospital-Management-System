using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdmin_PatientPageDAL
    {
        public List<Admin_PatientPageModel> GetPatientList();
        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel patient);

        public Admin_PatientPageModel GetPatientByID(int id);
        public Admin_PatientPageModel UpdatePatient(Admin_PatientPageModel patient, int Id);
        public void DeletePatient(int id);
        public AppointmentModel BookAppointment(AppointmentModel appointment);
    }
}
