using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface ILoginBAL
    {
        public List<UserModel> UserList();
        public UserModel SignUp(UserModel user);

        public string LoginPost(string email, string password);
    }
}
