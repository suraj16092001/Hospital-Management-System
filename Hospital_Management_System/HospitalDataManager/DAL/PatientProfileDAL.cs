using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
   
    public class PatientProfileDAL : IPatientProfileDAL
    {
        readonly IDBManager _dBManager;
        public PatientProfileDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }


        public PatientAllDataViewModel GetPatient_Profile(int id)
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
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return patient;
        }

    }
}
