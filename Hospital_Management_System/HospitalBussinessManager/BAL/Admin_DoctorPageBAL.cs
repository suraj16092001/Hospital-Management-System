using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Admin_DoctorPageBAL: IAdmin_DoctorPageBAL
    {
        IAdmin_DoctorPageDAL _IAdmin_DoctorPageDAL;
        public Admin_DoctorPageBAL(IDBManager dBManager)
        {

            _IAdmin_DoctorPageDAL = new Admin_DoctorPageDAL(dBManager) ;

        }

        public List<Admin_DoctorPageModel> GetDoctorList()
        {
           return _IAdmin_DoctorPageDAL.GetDoctorList(); 
        }

        public Admin_DoctorPageModel AddDoctor(Admin_DoctorPageModel model)
        {
            return _IAdmin_DoctorPageDAL.AddDoctor(model);
        }

        public void DeleteDoctor(int id)
        {
            _IAdmin_DoctorPageDAL.DeleteDoctor(id);
        }

        public Admin_DoctorPageModel GetDoctorByID(int id)
        {
            return _IAdmin_DoctorPageDAL.GetDoctorByID(id);
        }

        public string UpdateDoctor(Admin_DoctorPageModel model, int Id)
        {
            _IAdmin_DoctorPageDAL.UpdateDoctor(Id, model);
            return ("DoctorList");
        }
    }
}
