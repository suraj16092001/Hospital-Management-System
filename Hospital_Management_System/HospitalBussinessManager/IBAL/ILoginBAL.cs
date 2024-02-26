using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface ILoginBAL
    {
        public List<UserModel> UserList();
        public string SignUp(UserModel user);
        public LoginModel LoginPost(string email, string password, int id);
    }
}
