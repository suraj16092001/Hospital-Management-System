using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class DoctorProfileDAL : IDoctorProfileDAL
    {
        readonly IDBManager _dBManager;
        public DoctorProfileDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;

        }

        public DoctorAllDataViewModel GetDoctor_Profile(int id)
        {
            DoctorAllDataViewModel oModel = null;
            _dBManager.InitDbCommand("PopulateDoctorData");
            _dBManager.AddCMDParam("@p_id", id);
            _dBManager.ExecuteNonQuery();
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                oModel = new DoctorAllDataViewModel();
                oModel.User = new UserModel();
                oModel.admin_Doctor = new Admin_DoctorPageModel();

                oModel.User.id = item["id"].ConvertDBNullToInt();
                oModel.User.name = item["name"].ConvertDBNullToString();
                oModel.User.email = item["email"].ConvertDBNullToString();
                oModel.admin_Doctor.id = item["register_id"].ConvertDBNullToInt();
                oModel.admin_Doctor.qualification = item["qualification"].ConvertDBNullToString();
                oModel.admin_Doctor.specialist = item["specialist"].ConvertDBNullToString();
                oModel.admin_Doctor.gender = item["gender"].ConvertDBNullToString();
                oModel.admin_Doctor.phone = item["phone"].ConvertDBNullToString();
                oModel.admin_Doctor.DateOfBirth = item["DOB"].ConvertDBNullToString();
                oModel.admin_Doctor.address = item["address"].ConvertDBNullToString();
                oModel.admin_Doctor.profileImage = item["image"].ConvertDBNullToString();

            }

            return oModel;
        }

        public DoctorAllDataViewModel UpdateDoctor(DoctorAllDataViewModel model)
        {
            _dBManager.InitDbCommand("UpdateDoctorData");
            _dBManager.AddCMDParam("@p_name", model.User.name);
            _dBManager.AddCMDParam("@p_email", model.User.email);
            _dBManager.AddCMDParam("@p_id", model.User.id);
            _dBManager.AddCMDParam("@p_qualification", model.admin_Doctor.qualification);
            _dBManager.AddCMDParam("@p_specialist", model.admin_Doctor.specialist);
            _dBManager.AddCMDParam("@p_gender", model.admin_Doctor.gender);
            _dBManager.AddCMDParam("@p_phone", model.admin_Doctor.phone);
            _dBManager.AddCMDParam("@p_DOB", model.admin_Doctor.DateOfBirth);
            _dBManager.AddCMDParam("@p_address", model.admin_Doctor.address);
            _dBManager.AddCMDParam("@p_image", model.admin_Doctor.profileImage);

            _dBManager.ExecuteNonQuery();
            return model;
        }
    }
}
