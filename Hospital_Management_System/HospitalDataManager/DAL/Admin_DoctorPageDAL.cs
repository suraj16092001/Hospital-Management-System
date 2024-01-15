using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class Admin_DoctorPageDAL : IAdmin_DoctorPageDAL
    {
        readonly IDBManager _dBManager;
        public Admin_DoctorPageDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public List<Admin_DoctorPageModel> GetDoctorList()
        {
            List<Admin_DoctorPageModel> doctorList = new List<Admin_DoctorPageModel>();

            _dBManager.InitDbCommand("GetDoctorData");

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
               Admin_DoctorPageModel model = new Admin_DoctorPageModel();
                model.id = item["id"].ConvertDBNullToInt();
                model.name = item["name"].ConvertDBNullToString();
                model.qualification = item["qualification"].ConvertDBNullToString();
                model.specialist = item["specialist"].ConvertDBNullToString();
                model.gender = item["gender"].ConvertDBNullToString();
                model.phone = item["phone"].ConvertDBNullToString();
                model.email = item["email"].ConvertDBNullToString();
                model.age = item["age"].ConvertDBNullToString();
                model.address = item["address"].ConvertDBNullToString();

                doctorList.Add(model);
            }

            return doctorList;
        }

        public Admin_DoctorPageModel AddDoctor(Admin_DoctorPageModel model)
        {
            _dBManager.InitDbCommand("InsertDoctorData");
            _dBManager.AddCMDParam("@p_name", model.name);
            _dBManager.AddCMDParam("@p_qualification", model.qualification);
            _dBManager.AddCMDParam("@p_specialist", model.specialist);
            _dBManager.AddCMDParam("@p_gender", model.gender);
            _dBManager.AddCMDParam("@p_phone", model.phone);
            _dBManager.AddCMDParam("@p_email", model.email);
            _dBManager.AddCMDParam("@p_age", model.age);
            _dBManager.AddCMDParam("@p_address", model.address);

            _dBManager.ExecuteNonQuery();

            return model;

        }

        public void DeleteDoctor(int id)
        {
            _dBManager.InitDbCommand("DeleteDoctorByID");
            _dBManager.AddCMDParam("@p_id", id);
            _dBManager.ExecuteNonQuery();
        }

        public Admin_DoctorPageModel GetDoctorByID(int id)
        {
            Admin_DoctorPageModel doctor = null;
            _dBManager.InitDbCommand("GetDoctorByID");
            _dBManager.AddCMDParam("@p_id", id);
            _dBManager.ExecuteNonQuery();
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                doctor = new Admin_DoctorPageModel();

                doctor.id = item["id"].ConvertDBNullToInt();
                doctor.name = item["name"].ConvertDBNullToString();
                doctor.qualification = item["qualification"].ConvertDBNullToString();
                doctor.specialist = item["specialist"].ConvertDBNullToString();
                doctor.gender = item["gender"].ConvertDBNullToString();
                doctor.phone = item["phone"].ConvertDBNullToString();
                doctor.email = item["email"].ConvertDBNullToString();
                doctor.age = item["age"].ConvertDBNullToString();
                doctor.address = item["address"].ConvertDBNullToString();

            }

            return doctor;
        }
    }
}
