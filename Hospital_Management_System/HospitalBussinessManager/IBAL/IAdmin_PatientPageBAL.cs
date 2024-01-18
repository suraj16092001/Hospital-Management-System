using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdmin_PatientPageBAL
    {

        public List<Admin_PatientPageModel> GetPatientList();
        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel model);

        public Admin_PatientPageModel GetPatientByID(int id);
        public string UpdatePatient(Admin_PatientPageModel model, int Id);
        public void DeletePatient(int id);

        public AppointmentModel BookAppointment(AppointmentModel model);


    }
}