using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdminProfileBAL
    {
        public AdminAllDataViewModel GetAdmin_Profile(int id);
        public string UpdateAdmin(AdminAllDataViewModel model);
    }
}
