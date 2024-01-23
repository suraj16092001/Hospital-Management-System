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

        public List<Admin_PatientPageModel> GetPatientList()
        {
            List<Admin_PatientPageModel> patientList = new List<Admin_PatientPageModel>();

            _dBManager.InitDbCommand("GetPatientData");

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Admin_PatientPageModel admin_PatientPageModel = new Admin_PatientPageModel();
                admin_PatientPageModel.id = item["id"].ConvertDBNullToInt();
                admin_PatientPageModel.phone = item["phone"].ConvertDBNullToString();
                admin_PatientPageModel.age = item["age"].ConvertDBNullToString();
                admin_PatientPageModel.gender = item["gender"].ConvertDBNullToString();
                admin_PatientPageModel.DateOfBirth = item["DOB"].ConvertDBNullToString();
                admin_PatientPageModel.address = item["address"].ConvertDBNullToString();

                patientList.Add(admin_PatientPageModel);
            }

            return patientList;
        }


        public PatientAllDataViewModel AddPatient(PatientAllDataViewModel oModel)
        {
            _dBManager.InitDbCommand("insertData");
            _dBManager.AddCMDParam("@p_phone", oModel.Admin_PatientPage.phone);
            _dBManager.AddCMDParam("@p_age", oModel.Admin_PatientPage.age);
            _dBManager.AddCMDParam("@p_gender", oModel.Admin_PatientPage.gender);
            _dBManager.AddCMDParam("@p_DateOfBirth", oModel.Admin_PatientPage.DateOfBirth);
            _dBManager.AddCMDParam("@p_address", oModel.Admin_PatientPage.address);
            _dBManager.AddCMDParam("@p_name", oModel.User.name);
            _dBManager.AddCMDParam("@p_email", oModel.User.email);
            _dBManager.AddCMDParam("@p_password", oModel.User.password);
            _dBManager.AddCMDParam("@p_role_id", oModel.User.role);
            

            _dBManager.ExecuteNonQuery();
            
            return oModel;

        }

        public void DeletePatient(int id)
        {
            _dBManager.InitDbCommand("DeletePatientByID");
            _dBManager.AddCMDParam("p_id", id);

            _dBManager.ExecuteNonQuery();
        }

        public Admin_PatientPageModel GetPatientByID(int id)
        {

            _dBManager.InitDbCommand("GetAllPatientData");
            Admin_PatientPageModel admin_PatientPageModel = null;
            UserModel userModel = null;
            _dBManager.AddCMDParam("@p_id", id);
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                admin_PatientPageModel = new Admin_PatientPageModel();
                userModel = new UserModel();
                admin_PatientPageModel.id = item["id"].ConvertDBNullToInt();
                userModel.name = item["name"].ConvertDBNullToString();
                userModel.email = item["email"].ConvertDBNullToString();
                admin_PatientPageModel.age = item["age"].ConvertDBNullToString();
                admin_PatientPageModel.gender = item["gender"].ConvertDBNullToString();
                admin_PatientPageModel.register_id = item["register_id"].ConvertDBNullToInt();
                admin_PatientPageModel.DateOfBirth = item["DOB"].ConvertDBNullToString();
                admin_PatientPageModel.phone = item["phone"].ConvertDBNullToString();
                admin_PatientPageModel.address = item["address"].ConvertDBNullToString();

            }
            return admin_PatientPageModel;
        }


        public Admin_PatientPageModel UpdatePatient(Admin_PatientPageModel patient, int Id)
        {
            _dBManager.InitDbCommand("UpdatePatientData");
            _dBManager.AddCMDParam("@p_id", Id);
            _dBManager.AddCMDParam("@p_age", patient.age);
            _dBManager.AddCMDParam("@p_gender", patient.gender);
            _dBManager.AddCMDParam("@p_DateOfBirth", patient.DateOfBirth);
            _dBManager.AddCMDParam("@p_phone", patient.phone);
            _dBManager.AddCMDParam("@p_address", patient.address);

            _dBManager.ExecuteNonQuery();
            return patient;
        }

        public AppointmentModel BookAppointment(AppointmentModel appointment)
        {

            _dBManager.InitDbCommand("InsertPatientAppointment");
            _dBManager.AddCMDParam("@p_disease", appointment.disease);
            _dBManager.AddCMDParam("@p_doctor", appointment.doctor);
            _dBManager.AddCMDParam("@p_appointment_date", appointment.appointment_date);
            _dBManager.AddCMDParam("@p_appointment_time", appointment.appointment_time);

            _dBManager.ExecuteNonQuery();
            return appointment;
        }

    }
}
