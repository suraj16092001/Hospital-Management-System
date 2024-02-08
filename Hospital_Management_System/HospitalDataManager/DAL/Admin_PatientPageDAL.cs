using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class Admin_PatientPageDAL : IAdmin_PatientPageDAL
    {
        readonly IDBManager _dBManager;

        public Admin_PatientPageDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;

        }

        public List<PatientAllDataViewModel> GetPatientList()
        {
            List<PatientAllDataViewModel> patientList = new List<PatientAllDataViewModel>();

            _dBManager.InitDbCommand("GetAllPatientData");

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                PatientAllDataViewModel oModel = new PatientAllDataViewModel();

                oModel.User = new UserModel();
                oModel.Admin_PatientPage = new Admin_PatientPageModel();

                oModel.User.name = item["name"].ConvertDBNullToString();
                oModel.User.email = item["email"].ConvertDBNullToString();
                oModel.Admin_PatientPage.id = item["id"].ConvertDBNullToInt();
                oModel.Admin_PatientPage.phone = item["phone"].ConvertDBNullToString();
                oModel.Admin_PatientPage.gender = item["gender"].ConvertDBNullToString();
                oModel.Admin_PatientPage.DateOfBirth = item["DOB"].ConvertDBNullToString();
                oModel.Admin_PatientPage.address = item["address"].ConvertDBNullToString();

                patientList.Add(oModel);
            }

            return patientList;
        }


        public PatientAllDataViewModel AddPatient(PatientAllDataViewModel oModel)
        {
            oModel.User.password = oModel.User.password + _dBManager.GetSalt();
            _dBManager.InitDbCommand("insertData");

            _dBManager.AddCMDParam("@p_name", oModel.User.name);
            _dBManager.AddCMDParam("@p_email", oModel.User.email);
            _dBManager.AddCMDParam("@p_password", oModel.User.password);
            _dBManager.AddCMDParam("@p_role_id", oModel.User.role);
            _dBManager.AddCMDParam("@p_phone", oModel.Admin_PatientPage.phone);
            _dBManager.AddCMDParam("@p_gender", oModel.Admin_PatientPage.gender);
            _dBManager.AddCMDParam("@p_DateOfBirth", oModel.Admin_PatientPage.DateOfBirth);
            _dBManager.AddCMDParam("@p_address", oModel.Admin_PatientPage.address);

            _dBManager.ExecuteNonQuery();
            
            return oModel;

        }

        public void DeletePatient(int id)
        {
            _dBManager.InitDbCommand("DeletePatientData");
            _dBManager.AddCMDParam("p_id", id);

            _dBManager.ExecuteNonQuery();
        }

        public PatientAllDataViewModel GetPatientByID(int id)
        {
            PatientAllDataViewModel oModel = null;
          

            _dBManager.InitDbCommand("PopulatePatientData");
            _dBManager.AddCMDParam("@p_id", id);
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                oModel = new PatientAllDataViewModel();
                oModel.User = new UserModel();
                oModel.Admin_PatientPage = new Admin_PatientPageModel();

                oModel.User.name = item["name"].ConvertDBNullToString();
                oModel.User.email = item["email"].ConvertDBNullToString();
                oModel.Admin_PatientPage.id = item["id"].ConvertDBNullToInt();
                oModel.Admin_PatientPage.gender = item["gender"].ConvertDBNullToString();
                oModel.Admin_PatientPage.register_id = item["register_id"].ConvertDBNullToInt();
                oModel.Admin_PatientPage.DateOfBirth = item["DOB"].ConvertDBNullToString();
                oModel.Admin_PatientPage.phone = item["phone"].ConvertDBNullToString();
                oModel.Admin_PatientPage.address = item["address"].ConvertDBNullToString();
            }
            return oModel;
        }


        public PatientAllDataViewModel UpdatePatient(PatientAllDataViewModel patient)
        {
            _dBManager.InitDbCommand("UpdatePData");
            _dBManager.AddCMDParam("@p_id", patient.Admin_PatientPage.id);
            _dBManager.AddCMDParam("@p_name", patient.User.name);
            _dBManager.AddCMDParam("@p_email", patient.User.email);
            _dBManager.AddCMDParam("@p_gender", patient.Admin_PatientPage.gender);
            _dBManager.AddCMDParam("@p_DOB", patient.Admin_PatientPage.DateOfBirth);
            _dBManager.AddCMDParam("@p_phone", patient.Admin_PatientPage.phone);
            _dBManager.AddCMDParam("@p_address", patient.Admin_PatientPage.address);

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

        public List<UserModel> GetDoctors(Admin_DoctorPageModel specialist)
        {
            List<UserModel> DoctorList = new List<UserModel>();
            _dBManager.InitDbCommand("DoctorDropdown");
            _dBManager.AddCMDParam("@p_specialist", specialist.specialist);
            DataSet ds = _dBManager.ExecuteDataSet();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                UserModel oModel = new UserModel();
                oModel.id = item["id"].ConvertDBNullToInt();
                oModel.name = item["name"].ConvertDBNullToString();

                DoctorList.Add(oModel);
            }
            return DoctorList;

        }

    }
}
