using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface ILoginDAL
    {
        public List<UserModel> UserList();

        public UserModel SignUp(UserModel user);

        public string Login(string email);

        public bool CheckEmailExistence(string email);
        public string verifiedPassword(string password);
        public string getRole(string email);
        public int getID(string email);
    }
}
