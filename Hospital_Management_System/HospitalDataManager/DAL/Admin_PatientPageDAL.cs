﻿using CRUDoperation.CommonCode;
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
                admin_PatientPageModel.firstname= item["firstname"].ConvertDBNullToString();
                admin_PatientPageModel.lastname= item["lastname"].ConvertDBNullToString();
                admin_PatientPageModel.email= item["email"].ConvertDBNullToString();
                admin_PatientPageModel.age= item["age"].ConvertDBNullToString();
                admin_PatientPageModel.gender= item["gender"].ConvertDBNullToString();
                admin_PatientPageModel.disease= item["disease"].ConvertDBNullToString();
                admin_PatientPageModel.phone= item["phone"].ConvertDBNullToString();
                admin_PatientPageModel.address= item["address"].ConvertDBNullToString();

                patientList.Add(admin_PatientPageModel);
            }

            return patientList;
        }


        public Admin_PatientPageModel AddPatient(Admin_PatientPageModel patient)
        {
            _dBManager.InitDbCommand("InsertPatientData");
            _dBManager.AddCMDParam("@p_firstname", patient.firstname);
            _dBManager.AddCMDParam("@p_lastname", patient.lastname);
            _dBManager.AddCMDParam("@p_email", patient.email);
            _dBManager.AddCMDParam("@p_age", patient.age);
            _dBManager.AddCMDParam("@p_gender", patient.gender);
            _dBManager.AddCMDParam("@p_disease", patient.disease);
            _dBManager.AddCMDParam("@p_phone", patient.phone);
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

        public Admin_PatientPageModel GetPatientByID(int id)
        {
           
            _dBManager.InitDbCommand("GetPatientByID");
            Admin_PatientPageModel admin_PatientPageModel = null;
            _dBManager.AddCMDParam("@p_id", id);
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                admin_PatientPageModel = new Admin_PatientPageModel();

                admin_PatientPageModel.id = item["id"].ConvertDBNullToInt();
                admin_PatientPageModel.firstname = item["firstname"].ConvertDBNullToString();
                admin_PatientPageModel.lastname = item["lastname"].ConvertDBNullToString();
                admin_PatientPageModel.email = item["email"].ConvertDBNullToString();
                admin_PatientPageModel.age = item["age"].ConvertDBNullToString();
                admin_PatientPageModel.gender = item["gender"].ConvertDBNullToString();
                admin_PatientPageModel.disease = item["disease"].ConvertDBNullToString();
                admin_PatientPageModel.phone = item["phone"].ConvertDBNullToString(); 
                admin_PatientPageModel.address = item["address"].ConvertDBNullToString(); 

            }
            return admin_PatientPageModel;
        }


        public Admin_PatientPageModel UpdatePatient(Admin_PatientPageModel patient,int Id)
        {
            _dBManager.InitDbCommand("UpdatePatientData");
            _dBManager.AddCMDParam("@p_id", Id);
            _dBManager.AddCMDParam("@p_firstname", patient.firstname);
            _dBManager.AddCMDParam("@p_lastname", patient.lastname);
            _dBManager.AddCMDParam("@p_email", patient.email);
            _dBManager.AddCMDParam("@p_age", patient.age);
            _dBManager.AddCMDParam("@p_gender", patient.gender);
            _dBManager.AddCMDParam("@p_disease", patient.disease);
            _dBManager.AddCMDParam("@p_phone", patient.phone);
            _dBManager.AddCMDParam("@p_address", patient.address);

            _dBManager.ExecuteNonQuery();
            return patient;
        }
    }
}
