using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdminPageDAL
    {
		public List<AdminAllDataViewModel> GetAdminList();
		public AdminAllDataViewModel AddAdmin(AdminAllDataViewModel admin);
        public void DeleteAdmin(UserModel model, int id);
		public AdminAllDataViewModel GetAdminByID(int id);
		public AdminAllDataViewModel UpdateAdmin(AdminAllDataViewModel admin);
    }
}
