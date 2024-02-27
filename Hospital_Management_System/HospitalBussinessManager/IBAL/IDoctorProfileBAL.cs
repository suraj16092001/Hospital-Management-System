using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IDoctorProfileBAL
    {
        public DoctorAllDataViewModel GetDoctor_Profile(int id);
        public string UpdateDoctor(DoctorAllDataViewModel model, int Id, IFormFile file);
    }
}
