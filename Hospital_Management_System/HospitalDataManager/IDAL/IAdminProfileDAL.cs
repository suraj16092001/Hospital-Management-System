using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdminProfileDAL
    {
        public AdminAllDataViewModel GetAdmin_Profile(int id);
        public AdminAllDataViewModel UpdateAdmin(AdminAllDataViewModel admin);
    }
}
