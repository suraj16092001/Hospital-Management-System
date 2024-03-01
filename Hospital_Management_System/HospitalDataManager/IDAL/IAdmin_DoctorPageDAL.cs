using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdmin_DoctorPageDAL
    {
        public List<DoctorAllDataViewModel> GetDoctorList();

        public DoctorAllDataViewModel AddDoctor(DoctorAllDataViewModel model);

        public void DeleteDoctor(UserModel model, int id);
        public DoctorAllDataViewModel GetDoctorByID(int id);
        public DoctorAllDataViewModel UpdateDoctor(DoctorAllDataViewModel model);
        public string GetDBImagebyID(int ID);
    }
}
