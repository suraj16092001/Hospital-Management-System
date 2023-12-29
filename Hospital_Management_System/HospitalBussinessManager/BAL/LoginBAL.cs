using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.Models;
using System.Data;
using MySql.Data.MySqlClient;
using Hospital_Management_System.CommonCode;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class LoginBAL : ILoginBAL
    {
        ILoginDAL _ILoginDAL;

        public LoginBAL(IDBManager dBManager)
        {
            _ILoginDAL = new LoginDAL(dBManager);
        }

        public UserModel SignUp(UserModel user)
        {
            user.password = MD5Hash.GetMd5Hash(user.password);
            return _ILoginDAL.SignUp(user);
        }

        public List<UserModel> UserList()
        {
            return _ILoginDAL.UserList();
        }

        public string LoginPost(string email, string password)
        {
            string existingPass = _ILoginDAL.Login(email);
            bool result = MD5Hash.verifyPassword(existingPass, password);
            if (result)
            {
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }
    }
}
