using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class DoctorProfileBAL : IDoctorProfileBAL
    {
        IDoctorProfileDAL _IDoctorProfileDAL;
        ILoginDAL _ILoginDAL;
        IAdmin_DoctorPageDAL _IAdmin_DoctorPageDAL;
        IAdmin_DoctorPageBAL _IAdmin_DoctorPageBAL;
        public DoctorProfileBAL(IDBManager dBManager, IAdmin_DoctorPageBAL iAdmin_DoctorPageBAL)
        {
            _IDoctorProfileDAL = new DoctorProfileDAL(dBManager);
            _ILoginDAL = new LoginDAL(dBManager);

            _IAdmin_DoctorPageDAL = new Admin_DoctorPageDAL(dBManager);
            _IAdmin_DoctorPageBAL = iAdmin_DoctorPageBAL;
        }

        public DoctorAllDataViewModel GetDoctor_Profile(int id)
        {
            return _IDoctorProfileDAL.GetDoctor_Profile(id);
        }


        public string UpdateDoctor(DoctorAllDataViewModel model, int Id, IFormFile file)
        {
            model.User.id = Id;
            model.admin_Doctor.imageFile = file;
            bool emailExists = _ILoginDAL.CheckEmailExistence(model.User.email, model.User.id);

            if (emailExists)
            {
                return "exists";
            }
            string existingImage = _IAdmin_DoctorPageDAL.GetDBImagebyID(Id);

            if (model.admin_Doctor.imageFile != null)
            {
                if (!string.IsNullOrEmpty(existingImage))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DoctorImages", existingImage);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                model.admin_Doctor.profileImage = _IAdmin_DoctorPageBAL.UploadImage(model.admin_Doctor.imageFile);
            }
            else
            {
                model.admin_Doctor.profileImage = existingImage;
            }
            _IDoctorProfileDAL.UpdateDoctor(model);
            return "success";
        }
    }
}
