using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdmin_PatientPageDAL
    {
        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel patient);
    }
}
