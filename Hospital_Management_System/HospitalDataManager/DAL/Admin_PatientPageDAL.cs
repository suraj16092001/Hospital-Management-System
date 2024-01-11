using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalDataManager.DAL
{

    public class Admin_PatientPageDAL : IAdmin_PatientPageDAL
    {
        readonly IDBManager _dBManager;
        public Admin_PatientPageDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;

        }
        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel patient)
        {
            _dBManager.InitDbCommand("InsertPatientData");
            _dBManager.AddCMDParam("@p_firstname", patient.firstname);
            _dBManager.AddCMDParam("@p_lastname", patient.lastname);
            _dBManager.AddCMDParam("@p_email", patient.email);
            _dBManager.AddCMDParam("@p_age", patient.age);
            //_dBManager.AddCMDParam("@firstName", patient.gender);
            _dBManager.AddCMDParam("@p_disease", patient.disease);
            _dBManager.AddCMDParam("@p_phone", patient.phone);
            _dBManager.AddCMDParam("@p_address", patient.address);

            _dBManager.ExecuteNonQuery();

            return patient;

        }
    }
}
