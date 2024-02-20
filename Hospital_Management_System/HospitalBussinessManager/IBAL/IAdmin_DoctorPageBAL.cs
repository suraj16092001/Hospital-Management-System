using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdmin_DoctorPageBAL
    {
        public List<DoctorAllDataViewModel> GetDoctorList();
        public string AddDoctor(DoctorAllDataViewModel model, IFormFile file);
        public void DeleteDoctor(int id);

        public DoctorAllDataViewModel GetDoctorByID(int id);
        public DoctorAllDataViewModel UpdateDoctor(DoctorAllDataViewModel model, int Id, IFormFile file);
    }
}
