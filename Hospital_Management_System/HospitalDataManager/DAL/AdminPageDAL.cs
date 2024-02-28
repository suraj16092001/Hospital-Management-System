using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class AdminPageDAL: IAdminPageDAL
    {
        readonly IDBManager _dBManager;
        public AdminPageDAL(IDBManager dBManager)
        {

            _dBManager = dBManager;
        }

        public List<AdminAllDataViewModel> GetAdminList()
        {
            List<AdminAllDataViewModel> AdminList = new List<AdminAllDataViewModel>();
            try
            {

                _dBManager.InitDbCommand("GetAdminData");
                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    AdminAllDataViewModel oModel = new AdminAllDataViewModel();
                    oModel.User = new UserModel();
                    oModel.AdminPage = new AdminPageModel();

                    oModel.User.id = item["id"].ConvertDBNullToInt();
                    oModel.User.name = item["name"].ConvertDBNullToString();
                    oModel.User.email = item["email"].ConvertDBNullToString();
                    oModel.AdminPage.DateOfBirth = item["DOB"].ConvertDBNullToString();
                    oModel.AdminPage.gender = item["gender"].ConvertDBNullToString();
                    oModel.AdminPage.phone = item["phone"].ConvertDBNullToString();
                    oModel.AdminPage.address = item["address"].ConvertDBNullToString();

                    AdminList.Add(oModel);
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return AdminList;
        }

        public AdminAllDataViewModel AddAdmin(AdminAllDataViewModel admin)
        {
            try
            {
                admin.User.password = admin.User.password + _dBManager.GetSalt();
                _dBManager.InitDbCommand("InsertAdminData");
                _dBManager.AddCMDParam("@p_name", admin.User.name);
                _dBManager.AddCMDParam("@p_email", admin.User.email);
                _dBManager.AddCMDParam("@p_password", admin.User.password);
                _dBManager.AddCMDParam("@p_role_id", admin.User.role);
                _dBManager.AddCMDParam("@p_phone", admin.AdminPage.phone);
                _dBManager.AddCMDParam("@p_DOB", admin.AdminPage.DateOfBirth);
                _dBManager.AddCMDParam("@p_gender", admin.AdminPage.gender);
                _dBManager.AddCMDParam("@p_address", admin.AdminPage.address);

                _dBManager.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return admin;

        }
        public void DeleteAdmin(int id)
        {
            try
            {
                _dBManager.InitDbCommand("DeleteAdminByID");
                _dBManager.AddCMDParam("p_id", id);

                _dBManager.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public AdminAllDataViewModel GetAdminByID(int id)
        {
			AdminAllDataViewModel model = null;

            try
            {
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
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return model;
        }


        public AdminAllDataViewModel UpdateAdmin(AdminAllDataViewModel admin)
        {
            try
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
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return admin;
        }
    }
}
