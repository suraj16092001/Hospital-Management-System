using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdmin_DoctorPageBAL
    {
        public List<Admin_DoctorPageModel> GetDoctorList();
        public Admin_DoctorPageModel AddDoctor(Admin_DoctorPageModel model);
        public void DeleteDoctor(int id);

        public Admin_DoctorPageModel GetDoctorByID(int id);

    }
}
