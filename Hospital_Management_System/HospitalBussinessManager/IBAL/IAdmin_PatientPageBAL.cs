using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdmin_PatientPageBAL
    {
   
         public  List<UserModel> GetPatientList();
        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel model);

     
        public UserModel GetPatientByID(int id);

        public string UpdatePatient(UserModel model, int Id);
        public void DeletePatient(int id);
        public string RegisterPatient(UserModel user);

    }
}