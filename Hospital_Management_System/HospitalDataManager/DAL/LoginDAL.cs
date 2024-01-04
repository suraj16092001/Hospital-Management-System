using CRUDoperation.CommonCode;
using Hospital_Management_System.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    internal class LoginDAL : ILoginDAL
    {
        private IDBManager _dBManager;

        public LoginDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public List<UserModel> UserList() { 
            
            List<UserModel> userList = new List<UserModel>();

            _dBManager.InitDbCommandText("select * from loginUser;");

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach(DataRow item in ds.Tables[0].Rows)
            {
                UserModel userModel = new UserModel();

                userModel.id = item["id"].ConvertDBNullToInt();
                userModel.name = item["name"].ConvertDBNullToString();
                userModel.email = item["email"].ConvertDBNullToString();
                userModel.password = item["pass"].ConvertDBNullToString();

                userList.Add(userModel);

            }

            return userList;

        }

        public UserModel SignUp(UserModel user )
        {
            
            _dBManager.InitDbCommand("InsertUser");
            _dBManager.AddCMDParam("@p_name", user.name);
            _dBManager.AddCMDParam("@p_email", user.email);
            _dBManager.AddCMDParam("@p_pass", user.password);


            _dBManager.ExecuteNonQuery();

            return user;
        }

        public bool CheckEmailExistence(string email)
        {
            _dBManager.InitDbCommand("CheckEmailExist")
                .AddCMDParam("@p_email",email);

            var result = _dBManager.ExecuteScalar();

            bool emailExists = Convert.ToBoolean(result);

            return emailExists;
        }
        public string Login(string email)
        {
            string existingPass = null;

            _dBManager.InitDbCommand("getUserPassword")
                .AddCMDParam("@p_email", email);

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                existingPass = item["pass"].ConvertDBNullToString();

            }
            return existingPass;

        }

        public string getPassword(string password)
        {
            _dBManager.InitDbCommand("getPassword")
                .AddCMDParam ("p_password", password);

            var result = _dBManager.ExecuteScalar();

            string passwordExixts = Convert.ToString(result);

            return passwordExixts;
        }
    }
}