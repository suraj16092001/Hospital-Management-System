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
            
            _dBManager.InitDbCommandText("insert into loginUser (name,email,pass) values (@name,@email,@pass);");
            _dBManager.AddCMDParam("@name", user.name);
            _dBManager.AddCMDParam("@email", user.email);
            _dBManager.AddCMDParam("@pass", user.password);


            _dBManager.ExecuteNonQuery();

            return user;
        }

        public string Login(string email)
        {
            string existingPass = null;

            _dBManager.InitDbCommandText("Select pass from loginUser where email=@email")
                .AddCMDParam("@email", email);

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                existingPass = item["pass"].ConvertDBNullToString();

            }
                return existingPass;

        }
    }
}