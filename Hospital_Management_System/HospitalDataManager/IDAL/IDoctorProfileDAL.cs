using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IDoctorProfileDAL
    {
        public DoctorAllDataViewModel GetDoctor_Profile(int id);
        public DoctorAllDataViewModel UpdateDoctor(DoctorAllDataViewModel model);
    }
}
