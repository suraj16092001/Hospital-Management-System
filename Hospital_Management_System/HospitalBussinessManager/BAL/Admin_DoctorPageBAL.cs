﻿using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Admin_DoctorPageBAL: IAdmin_DoctorPageBAL
    {
        IAdmin_DoctorPageDAL _IAdmin_DoctorPageDAL;
        ILoginDAL _ILoginDAL;
        public Admin_DoctorPageBAL(IDBManager dBManager)
        {

            _IAdmin_DoctorPageDAL = new Admin_DoctorPageDAL(dBManager) ;
            _ILoginDAL =new LoginDAL(dBManager) ;
        }

        public List<DoctorAllDataViewModel> GetDoctorList()
        {
           return _IAdmin_DoctorPageDAL.GetDoctorList(); 
        }

        public string AddDoctor(DoctorAllDataViewModel model, IFormFile file)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(model.User.email);

            if (emailExists)
            {
                return "exists";
            }
            model.admin_Doctor.imageFile = file;
            model.admin_Doctor.imagePath = UploadImage(model.admin_Doctor.imageFile);
            model.User.role = 3;
            _IAdmin_DoctorPageDAL.AddDoctor(model);
            return "success";
        }

        public string UploadImage(IFormFile imageFile)
        {
            try
            {
                string uniqueFileName = null;

                if (imageFile != null)
                {
                    string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                    // Create the directory if it doesn't exist

                    Console.WriteLine(Directory.GetCurrentDirectory());

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                }
                else
                {
                    Console.WriteLine("Image file path is null");
                }

                return uniqueFileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public void DeleteDoctor(int id)
        {
            _IAdmin_DoctorPageDAL.DeleteDoctor(id);
        }

        public DoctorAllDataViewModel GetDoctorByID(int id)
        {
            return _IAdmin_DoctorPageDAL.GetDoctorByID(id);
        }

        public DoctorAllDataViewModel UpdateDoctor(DoctorAllDataViewModel model)
        {

            return _IAdmin_DoctorPageDAL.UpdateDoctor(model);
        }
    }
}
