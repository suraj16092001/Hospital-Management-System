﻿using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class Admin_DoctorPageDAL : IAdmin_DoctorPageDAL
    {
        readonly IDBManager _dBManager;
        public Admin_DoctorPageDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }
            
        public List<DoctorAllDataViewModel> GetDoctorList()
        {
            List<DoctorAllDataViewModel> doctorList = new List<DoctorAllDataViewModel>();

            try
            {
                _dBManager.InitDbCommand("GetAllDoctorData");

                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    DoctorAllDataViewModel model = new DoctorAllDataViewModel();

                    model.User = new UserModel();
                    model.admin_Doctor = new Admin_DoctorPageModel();

                    model.User.id = item["id"].ConvertDBNullToInt();
                    model.User.name = item["name"].ConvertDBNullToString();
                    model.User.email = item["email"].ConvertDBNullToString();
                    model.admin_Doctor.qualification = item["qualification"].ConvertDBNullToString();
                    model.admin_Doctor.specialist = item["specialist"].ConvertDBNullToString();
                    model.admin_Doctor.qualification = item["qualification"].ConvertDBNullToString();
                    model.admin_Doctor.gender = item["gender"].ConvertDBNullToString();
                    model.admin_Doctor.phone = item["phone"].ConvertDBNullToString();
                    model.admin_Doctor.DateOfBirth = item["DOB"].ConvertDBNullToString();
                    model.admin_Doctor.address = item["address"].ConvertDBNullToString();
                    model.admin_Doctor.profileImage = item["image"].ConvertDBNullToString();

                    doctorList.Add(model);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return doctorList;
        }

        public DoctorAllDataViewModel AddDoctor(DoctorAllDataViewModel model)
        {
           
            model.User.password = model.User.password + _dBManager.GetSalt();
            try
            {
                int isDeleted = 0;
                _dBManager.InitDbCommand("InsertDoctorData");
                _dBManager.AddCMDParam("@p_name", model.User.name);
                _dBManager.AddCMDParam("@p_password", model.User.password);
                _dBManager.AddCMDParam("@p_email", model.User.email);
                _dBManager.AddCMDParam("@p_role_id", model.User.role);
                _dBManager.AddCMDParam("@p_qualification", model.admin_Doctor.qualification);
                _dBManager.AddCMDParam("@p_specialist", model.admin_Doctor.specialist);
                _dBManager.AddCMDParam("@p_gender", model.admin_Doctor.gender);
                _dBManager.AddCMDParam("@p_phone", model.admin_Doctor.phone);
                _dBManager.AddCMDParam("@p_DOB", model.admin_Doctor.DateOfBirth);
                _dBManager.AddCMDParam("@p_address", model.admin_Doctor.address);
                _dBManager.AddCMDParam("@p_Image", model.admin_Doctor.profileImage);
                _dBManager.AddCMDParam("@p_created_by", model.User.created_by);
                _dBManager.AddCMDParam("@p_created_at", model.User.created_at);
                _dBManager.AddCMDParam("@p_isDeleted", isDeleted);

                _dBManager.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return model;

        }

        public void DeleteDoctor(UserModel model,int id)
        {
           
            try
            {
                int isDeleted = 1;

                _dBManager.InitDbCommand("DeleteDoctorByID");
                _dBManager.AddCMDParam("@p_id", id);
                _dBManager.AddCMDParam("@p_isDeleted", isDeleted);
                _dBManager.AddCMDParam("@p_deleted_by", model.deleted_by);
                _dBManager.AddCMDParam("@p_deleted_at", model.deleted_at);
                _dBManager.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }

        public DoctorAllDataViewModel GetDoctorByID(int id)
        {
            DoctorAllDataViewModel oModel = null;
            try
            {
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
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return oModel;
        }

        public string GetDBImagebyID(int ID)
        {
            string existingImage = null;

            try
            {
                _dBManager.InitDbCommand("GetDBImagebyID");

                _dBManager.AddCMDParam("@p_ID", ID);

                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    existingImage = item["image"].ConvertJSONNullToString();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return existingImage;
        }

        public DoctorAllDataViewModel UpdateDoctor(DoctorAllDataViewModel model)
        {
            try
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
                _dBManager.AddCMDParam("@p_updated_by", model.User.updated_by);
                _dBManager.AddCMDParam("@p_updated_at", model.User.updated_at);

                _dBManager.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return model;
        }
    }
}
