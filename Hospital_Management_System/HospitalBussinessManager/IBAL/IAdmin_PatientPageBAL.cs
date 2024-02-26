using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdmin_PatientPageBAL
    {

        public List<PatientAllDataViewModel> GetPatientList();
        public string AddPatient(PatientAllDataViewModel oModel);
        public PatientAllDataViewModel GetPatientByID(int id);
        public string UpdatePatient(PatientAllDataViewModel model);
        public void DeletePatient(int id);
        public List<UserModel> GetDoctors(Admin_DoctorPageModel specialist);
        public Task<string> AdminSidePatientAppointment(Requested_AppointmentModel oModel);

    }
}