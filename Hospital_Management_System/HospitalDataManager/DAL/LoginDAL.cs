using CRUDoperation.CommonCode;
using Hospital_Management_System.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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

        public List<UserModel> UserList()
        {

            List<UserModel> userList = new List<UserModel>();

            try
            {
                _dBManager.InitDbCommand("GetAllUser");

                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    UserModel userModel = new UserModel();

                    userModel.id = item["id"].ConvertDBNullToInt();
                    userModel.name = item["name"].ConvertDBNullToString();
                    userModel.email = item["email"].ConvertDBNullToString();
                    userModel.password = item["pass"].ConvertDBNullToString();

                    userList.Add(userModel);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return userList;

        }

        public UserModel SignUp(UserModel user)
        {
            try
            {
                user.password = user.password + _dBManager.GetSalt();

                _dBManager.InitDbCommand("InsertUser");
                _dBManager.AddCMDParam("@p_name", user.name);
                _dBManager.AddCMDParam("@p_email", user.email);
                _dBManager.AddCMDParam("@p_pass", user.password);
                _dBManager.AddCMDParam("@p_role_id", user.role);


                _dBManager.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return user;
        }
        //check email from datatbase is same as input email or not and return bool value
        public bool CheckEmailExistence(string email, int id)
        {
            bool emailExists=false;
            try
            {
                _dBManager.InitDbCommand("CheckEmailExist")
               .AddCMDParam("@p_email", email)
               .AddCMDParam("@p_id", id);
                var result = _dBManager.ExecuteScalar();
                emailExists = Convert.ToBoolean(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
         
            return emailExists;
        }



        //retrieve role by emailID from database
        public string getRole(string email)
        {
            string role = "";
            try
            {
                _dBManager.InitDbCommand("getRole")
               .AddCMDParam("@p_email", email);
                var result = _dBManager.ExecuteScalar();

                role = Convert.ToString(result);
            }
            catch( Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }
            
            return role;
        }

        public string Login(string email)
        {
            string existingPass = "";
            //Retrive password from database by emailID
            try
            {
                _dBManager.InitDbCommand("getUserPassword")
                .AddCMDParam("@p_email", email);

                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    existingPass = item["pass"].ConvertDBNullToString();

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return existingPass;

        }

        // use to adding salt key and then convet into hash return hash value to bal
        public string verifiedPassword(string password)
        {
            string passwordExixts = "";
            try
            {
                password = password + _dBManager.GetSalt();
                _dBManager.InitDbCommand("verifiedPasswordUsingMD5")
                    .AddCMDParam("p_password", password);

                var result = _dBManager.ExecuteScalar();

                passwordExixts = Convert.ToString(result);
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return passwordExixts;
        }

        public int getID(string email)
        {
            int id = 0;
            try
            {
                _dBManager.InitDbCommand("getID")
                .AddCMDParam("@p_email", email);
                var result = _dBManager.ExecuteScalar();

                id = Convert.ToInt32(result);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return id;
        }

    }
}