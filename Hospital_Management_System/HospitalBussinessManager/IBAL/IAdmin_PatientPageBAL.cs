using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdmin_PatientPageBAL
    {

        public List<PatientAllDataViewModel> GetPatientList();
        public PatientAllDataViewModel AddPatient(PatientAllDataViewModel oModel);

        public PatientAllDataViewModel GetPatientByID(int id);
        public string UpdatePatient(PatientAllDataViewModel model, int Id);
        public void DeletePatient(int id);
        public AppointmentModel BookAppointment(AppointmentModel model);

    }
}