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

        public string SignUp(UserModel user)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(user.email);

            if (emailExists)
            {
                return "exists";
            } 
            
            _ILoginDAL.SignUp(user);

            return "success";
        }

        public List<UserModel> UserList()
        {
            return _ILoginDAL.UserList();
        }

        public string LoginPost(string email, string password)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(email);

            string getPassword =_ILoginDAL.verifiedPassword(password);

            string dbPassword = _ILoginDAL.Login(email);

            if(!emailExists)
            {
                return "not exists";
            }
            else if (getPassword != dbPassword)
            {
                return "Invalid Password";
            }
            else
            {
                return "Valid Password";
            }
        }
    }
}
