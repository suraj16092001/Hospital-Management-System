using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdminPageBAL
    {
		List<AdminAllDataViewModel> GetAdminList();
        public string AddAdmin(AdminAllDataViewModel model);
         public void DeleteAdmin(int id);
		public AdminAllDataViewModel GetAdminByID(int id);
		public AdminAllDataViewModel UpdateAdmin(AdminAllDataViewModel model);
    }
}
