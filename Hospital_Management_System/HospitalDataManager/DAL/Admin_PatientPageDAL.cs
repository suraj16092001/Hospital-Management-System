using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{

    public class Admin_PatientPageDAL : IAdmin_PatientPageDAL
    {
        readonly IDBManager _dBManager;
        
        public Admin_PatientPageDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;

        }


        public List<UserModel> GetPatientList()
        {
            List<UserModel> patientList = new List<UserModel>();

            _dBManager.InitDbCommand("GetPatientData");

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                UserModel model = new UserModel();
                model.id = item["id"].ConvertDBNullToInt();
                model.name = item["name"].ConvertDBNullToString();
                model.email = item["email"].ConvertDBNullToString();
               

                patientList.Add(model);
            }

            return patientList;
        }



        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel patient)
        {
            _dBManager.InitDbCommand("InsertPatientData");
            _dBManager.AddCMDParam("@p_firstname", patient.firstname);
            _dBManager.AddCMDParam("@p_lastname", patient.lastname);
            _dBManager.AddCMDParam("@p_email", patient.email);
            _dBManager.AddCMDParam("@p_phone", patient.phone);
            _dBManager.AddCMDParam("@p_age", patient.age);
            _dBManager.AddCMDParam("@p_gender", patient.gender);
            _dBManager.AddCMDParam("@p_disease", patient.disease);
            _dBManager.AddCMDParam("@p_address", patient.address);

            _dBManager.ExecuteNonQuery();

            return patient;

        }

        public void DeletePatient(int id)
        {
            _dBManager.InitDbCommand("DeletePatientByID");
            _dBManager.AddCMDParam("p_id", id);

            _dBManager.ExecuteNonQuery();
        }


        public UserModel GetPatientByID(int id)
        {

            _dBManager.InitDbCommand("GetSignuUpPatientByID");
            UserModel model = null;
            _dBManager.AddCMDParam("@p_id", id);
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                model = new UserModel();

                model.id = item["id"].ConvertDBNullToInt();
                model.name = item["name"].ConvertDBNullToString();
                model.email = item["email"].ConvertDBNullToString();

            }
            return model;
        }


        public UserModel UpdatePatient(UserModel patient, int Id)
        {
            _dBManager.InitDbCommand("UpdatePatient");
            _dBManager.AddCMDParam("@p_id", Id);
            _dBManager.AddCMDParam("@p_name", patient.name);
            _dBManager.AddCMDParam("@p_email", patient.email);

            _dBManager.ExecuteNonQuery();
            return patient;
        }
        public UserModel RegisterPatient(UserModel user)
        {
            user.password = user.password + _dBManager.GetSalt();

            _dBManager.InitDbCommand("InsertUser");
            _dBManager.AddCMDParam("@p_name", user.name);
            _dBManager.AddCMDParam("@p_email", user.email);
            _dBManager.AddCMDParam("@p_pass", user.password);
            _dBManager.AddCMDParam("@p_role", user.role);


            _dBManager.ExecuteNonQuery();

            return user;
        }

        public bool CheckEmailExistence(string email)
        {
            _dBManager.InitDbCommand("CheckEmailExist")
                .AddCMDParam("@p_email", email);

            var result = _dBManager.ExecuteScalar();

            bool emailExists = Convert.ToBoolean(result);

            return emailExists;
        }

    }
}
