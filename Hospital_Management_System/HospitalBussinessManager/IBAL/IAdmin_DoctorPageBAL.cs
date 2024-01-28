using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdmin_DoctorPageBAL
    {
        public List<DoctorAllDataViewModel> GetDoctorList();
        public DoctorAllDataViewModel AddDoctor(DoctorAllDataViewModel model);
        public void DeleteDoctor(int id);

        public DoctorAllDataViewModel GetDoctorByID(int id);
        public DoctorAllDataViewModel UpdateDoctor(DoctorAllDataViewModel model);
    }
}
