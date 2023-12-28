using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.Models;
using System.Data;
using MySql.Data.MySqlClient;

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
            return _ILoginDAL.SignUp(user);
        }

        public List<UserModel> UserList()
        {
            return _ILoginDAL.UserList();
        }

        public string LoginPost(string email, string password)
        {
            string existingPass = _ILoginDAL.Login(email);
            if (existingPass == password)
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
