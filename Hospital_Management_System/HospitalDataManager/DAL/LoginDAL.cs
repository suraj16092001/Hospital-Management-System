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

            _dBManager.InitDbCommand("GetAllUser");

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
            user.password = user.password + _dBManager.GetSalt();

            _dBManager.InitDbCommand("InsertUser");
            _dBManager.AddCMDParam("@p_name", user.name);
            _dBManager.AddCMDParam("@p_email", user.email);
            _dBManager.AddCMDParam("@p_pass", user.password);
            _dBManager.AddCMDParam("@p_role", user.role);


            _dBManager.ExecuteNonQuery();

            return user;
        }
        //check email from datatbase is same as input email or not and return bool value
        public bool CheckEmailExistence(string email)
        {
            _dBManager.InitDbCommand("CheckEmailExist")
                .AddCMDParam("@p_email",email);

            var result = _dBManager.ExecuteScalar();

            bool emailExists = Convert.ToBoolean(result);

            return emailExists;
        }

        //retrieve role by emailID from database
        public string getRole(string email)
        {
            _dBManager.InitDbCommand("getRole")
                .AddCMDParam("@p_email", email);
            var result = _dBManager.ExecuteScalar();

            string role= Convert.ToString(result);
            return role;
        }

        public string Login(string email)
        {
            string existingPass = null;
            //Retrive password from database by emailID
            _dBManager.InitDbCommand("getUserPassword")
                .AddCMDParam("@p_email", email);

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                existingPass = item["pass"].ConvertDBNullToString();

            }
            return existingPass;

        }

        // use to adding salt key and then convet into hash return hash value to bal
        public string verifiedPassword(string password)
        {
            password = password + _dBManager.GetSalt();
            _dBManager.InitDbCommand("getPassword")
                .AddCMDParam ("p_password", password);

            var result = _dBManager.ExecuteScalar();

            string passwordExixts = Convert.ToString(result);

            return passwordExixts;
        }
    }
}