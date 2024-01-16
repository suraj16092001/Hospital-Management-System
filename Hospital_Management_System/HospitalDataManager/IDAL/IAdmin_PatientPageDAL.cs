using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdmin_PatientPageDAL
    {
        public List<UserModel> GetPatientList();
        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel patient);
        public UserModel GetPatientByID(int id);
 
        public UserModel UpdatePatient(UserModel patient, int Id);
        public void DeletePatient(int id);
        public UserModel RegisterPatient(UserModel user);

        public bool CheckEmailExistence(string email);
    }
}
