using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class AdminPageDAL: IAdminPageDAL
    {
        readonly IDBManager _dBManager;
        public AdminPageDAL(IDBManager dBManager)
        {

            _dBManager = dBManager;
        }

        public List<AdminPageModel> GetAdminList()
        {
            List<AdminPageModel> AdminList = new List<AdminPageModel>();

            _dBManager.InitDbCommand("GetAdminData");
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                AdminPageModel adminPageModel = new AdminPageModel();

                adminPageModel.id = item["id"].ConvertDBNullToInt();
                adminPageModel.name = item["name"].ConvertDBNullToString();
                //adminPageModel.password = item["password"].ConvertDBNullToString();
                adminPageModel.email = item["email"].ConvertDBNullToString();
                adminPageModel.age = item["age"].ConvertDBNullToString();
                adminPageModel.gender = item["gender"].ConvertDBNullToString();
                adminPageModel.phone = item["phone"].ConvertDBNullToString();
                adminPageModel.address = item["address"].ConvertDBNullToString();

                AdminList.Add(adminPageModel);
            }

            return AdminList;
        }

        public AdminPageModel AddAdmin(AdminPageModel admin)
        {
            _dBManager.InitDbCommand("InsertAdminData");
            _dBManager.AddCMDParam("@p_name", admin.name);
            _dBManager.AddCMDParam("@p_email", admin.email);
            _dBManager.AddCMDParam("@p_password", admin.password);
            _dBManager.AddCMDParam("@p_phone", admin.phone);
            _dBManager.AddCMDParam("@p_age", admin.age);
            _dBManager.AddCMDParam("@p_gender", admin.gender);
            _dBManager.AddCMDParam("@p_address", admin.address);

            _dBManager.ExecuteNonQuery();

            return admin;

        }
        public void DeleteAdmin(int id)
        {
            _dBManager.InitDbCommand("DeleteAdminByID");
            _dBManager.AddCMDParam("p_id", id);

            _dBManager.ExecuteNonQuery();
        }


        public AdminPageModel GetAdminByID(int id)
        {

            _dBManager.InitDbCommand("GetAdminByID");
            AdminPageModel adminPage = null;
            _dBManager.AddCMDParam("@p_id", id);
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                adminPage = new AdminPageModel();

                adminPage.id = item["id"].ConvertDBNullToInt();
                adminPage.name = item["name"].ConvertDBNullToString();
                adminPage.email = item["email"].ConvertDBNullToString();
                adminPage.age = item["age"].ConvertDBNullToString();
                adminPage.gender = item["gender"].ConvertDBNullToString();
                adminPage.phone = item["phone"].ConvertDBNullToString();
                adminPage.address = item["address"].ConvertDBNullToString();

            }
            return adminPage;
        }


        public AdminPageModel UpdateAdmin(AdminPageModel admin, int Id)
        {
            _dBManager.InitDbCommand("UpdateAdminData");
            _dBManager.AddCMDParam("@p_id", Id);
            _dBManager.AddCMDParam("@p_name", admin.name);
            _dBManager.AddCMDParam("@p_email", admin.email);
            _dBManager.AddCMDParam("@p_age", admin.age);
            _dBManager.AddCMDParam("@p_gender", admin.gender);
            _dBManager.AddCMDParam("@p_phone", admin.phone);
            _dBManager.AddCMDParam("@p_address", admin.address);

            _dBManager.ExecuteNonQuery();
            return admin;
        }
    }
}
