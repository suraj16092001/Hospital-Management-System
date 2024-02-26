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
            bool emailExists = _ILoginDAL.CheckEmailExistence(user.email, user.id);

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

        public LoginModel LoginPost(string email, string password,int id)
        {
            LoginModel login= new LoginModel();

          login.EmailExists = _ILoginDAL.CheckEmailExistence(email,id);

          login.GetPassword = _ILoginDAL.verifiedPassword(password);

          login.GetRole = _ILoginDAL.getRole(email);

          login.DbPassword = _ILoginDAL.Login(email);

            login.Id = _ILoginDAL.getID(email);
            return login;
          
        }
    }
}


// return new { EmailExists = emailExists, GetPassword = getPassword, GetRole = getRole };

//if (!emailExists)
//{
//    return "not exists";
//}
//else if (getPassword != dbPassword)
//{
//    return "Invalid Password";
//}
//else if (getRole)
//{
//    return "Valid Password";
//}
//return "Valid Password";