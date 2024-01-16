using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdmin_DoctorPageDAL
    {
        public List<Admin_DoctorPageModel> GetDoctorList();

        public Admin_DoctorPageModel AddDoctor(Admin_DoctorPageModel model);

        public void DeleteDoctor(int id);
        public Admin_DoctorPageModel GetDoctorByID(int id);
        public Admin_DoctorPageModel UpdateDoctor(int Id, Admin_DoctorPageModel model);
    }
}
