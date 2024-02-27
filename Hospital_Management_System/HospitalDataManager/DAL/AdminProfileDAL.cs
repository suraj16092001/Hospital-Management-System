using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class AdminProfileDAL : IAdminProfileDAL
    {
        readonly IDBManager _dBManager;
        public AdminProfileDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public AdminAllDataViewModel GetAdmin_Profile(int id)
        {
            AdminAllDataViewModel model = null;

            _dBManager.InitDbCommand("PopulateAdminData");
            _dBManager.AddCMDParam("@p_id", id);
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                model = new AdminAllDataViewModel();
                model.User = new UserModel();
                model.AdminPage = new AdminPageModel();

                model.User.id = item["id"].ConvertDBNullToInt();
                model.User.name = item["name"].ConvertDBNullToString();
                model.User.email = item["email"].ConvertDBNullToString();
                model.AdminPage.DateOfBirth = item["DOB"].ConvertDBNullToString();
                model.AdminPage.gender = item["gender"].ConvertDBNullToString();
                model.AdminPage.phone = item["phone"].ConvertDBNullToString();
                model.AdminPage.address = item["address"].ConvertDBNullToString();

            }
            return model;
        }

        public AdminAllDataViewModel UpdateAdmin(AdminAllDataViewModel admin)
        {
            _dBManager.InitDbCommand("UpdateAdminData");
            _dBManager.AddCMDParam("@p_id", admin.User.id);
            _dBManager.AddCMDParam("@p_name", admin.User.name);
            _dBManager.AddCMDParam("@p_email", admin.User.email);
            _dBManager.AddCMDParam("@p_DateOfBirth", admin.AdminPage.DateOfBirth);
            _dBManager.AddCMDParam("@p_gender", admin.AdminPage.gender);
            _dBManager.AddCMDParam("@p_phone", admin.AdminPage.phone);
            _dBManager.AddCMDParam("@p_address", admin.AdminPage.address);

            _dBManager.ExecuteNonQuery();
            return admin;
        }

    }
}
