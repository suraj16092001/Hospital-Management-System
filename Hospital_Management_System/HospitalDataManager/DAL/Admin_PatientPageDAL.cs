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

            try
            {
                _dBManager.InitDbCommand("GetAllPatientData");

                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PatientAllDataViewModel oModel = new PatientAllDataViewModel();

                    oModel.User = new UserModel();
                    oModel.Admin_PatientPage = new Admin_PatientPageModel();

                    oModel.User.id = item["id"].ConvertDBNullToInt();
                    oModel.User.name = item["name"].ConvertDBNullToString();
                    oModel.User.email = item["email"].ConvertDBNullToString();
                    oModel.Admin_PatientPage.phone = item["phone"].ConvertDBNullToString();
                    oModel.Admin_PatientPage.gender = item["gender"].ConvertDBNullToString();
                    oModel.Admin_PatientPage.DateOfBirth = item["DOB"].ConvertDBNullToString();
                    oModel.Admin_PatientPage.address = item["address"].ConvertDBNullToString();

                    patientList.Add(oModel);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return patientList;
        }


        public PatientAllDataViewModel AddPatient(PatientAllDataViewModel oModel)
        {
            try
            {
                int isDeleted = 0;
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
                _dBManager.AddCMDParam("@p_created_by", oModel.User.created_by);
                _dBManager.AddCMDParam("@p_created_at", oModel.User.created_at);
                _dBManager.AddCMDParam("@p_isDeleted", isDeleted);

                _dBManager.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString() );
            }
            return oModel;

        }

        public void DeletePatient(UserModel model, int id)
        {
            try
            {
                int isDeleted = 1;
                _dBManager.InitDbCommand("DeletePatientData");
                _dBManager.AddCMDParam("p_id", id);
                _dBManager.AddCMDParam("@p_isDeleted", isDeleted);
                _dBManager.AddCMDParam("@p_deleted_by", model.deleted_by);
                _dBManager.AddCMDParam("@p_deleted_at", model.deleted_at);
                _dBManager.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }
        }

        public PatientAllDataViewModel GetPatientByID(int id)
        {
            PatientAllDataViewModel oModel = null;
            try
            {
                _dBManager.InitDbCommand("PopulatePatientData");
                _dBManager.AddCMDParam("@p_id", id);
                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    oModel = new PatientAllDataViewModel();
                    oModel.User = new UserModel();
                    oModel.Admin_PatientPage = new Admin_PatientPageModel();

                    oModel.User.id = item["id"].ConvertDBNullToInt();
                    oModel.User.name = item["name"].ConvertDBNullToString();
                    oModel.User.email = item["email"].ConvertDBNullToString();
                    oModel.Admin_PatientPage.id = item["id"].ConvertDBNullToInt();
                    oModel.Admin_PatientPage.gender = item["gender"].ConvertDBNullToString();
                    oModel.Admin_PatientPage.register_id = item["register_id"].ConvertDBNullToInt();
                    oModel.Admin_PatientPage.DateOfBirth = item["DOB"].ConvertDBNullToString();
                    oModel.Admin_PatientPage.phone = item["phone"].ConvertDBNullToString();
                    oModel.Admin_PatientPage.address = item["address"].ConvertDBNullToString();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return oModel;
        }

        public PatientAllDataViewModel UpdatePatient(PatientAllDataViewModel patient)
        {
            try
            {
                _dBManager.InitDbCommand("UpdatePatientData");
                _dBManager.AddCMDParam("@p_id", patient.User.id);
                _dBManager.AddCMDParam("@p_name", patient.User.name);
                _dBManager.AddCMDParam("@p_email", patient.User.email);
                _dBManager.AddCMDParam("@p_gender", patient.Admin_PatientPage.gender);
                _dBManager.AddCMDParam("@p_DateOfBirth", patient.Admin_PatientPage.DateOfBirth);
                _dBManager.AddCMDParam("@p_phone", patient.Admin_PatientPage.phone);
                _dBManager.AddCMDParam("@p_address", patient.Admin_PatientPage.address);
                _dBManager.AddCMDParam("@p_updated_by", patient.User.updated_by);
                _dBManager.AddCMDParam("@p_updated_at", patient.User.updated_at);

                _dBManager.ExecuteNonQuery();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return patient;
        }

        public List<UserModel> GetDoctors(Admin_DoctorPageModel specialist)
        {
            List<UserModel> DoctorList = new List<UserModel>();
            try
            {
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
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return DoctorList;

        }

        public bool CheckDateTimeOfDoctorsAvailability(Requested_AppointmentModel patient)
        {
            _dBManager.InitDbCommand("sp_hospital_adminpatientpage_CheckDateTimeOfDoctorsAvailability")
                .AddCMDParam("@p_appointment_date_in", patient.appointment_date)
                .AddCMDParam("@p_appointment_time_in", patient.appointment_time)
                .AddCMDParam("@p_department_in", patient.department)
                .AddCMDParam("@p_doctor_id_in", patient.doctor_id);
                //.AddCMDParam("@p_status_id_in", patient.status_id);

            var result = _dBManager.ExecuteScalar();

            bool TimeDateExists = Convert.ToBoolean(result);

            return TimeDateExists;
        }

    }
}
