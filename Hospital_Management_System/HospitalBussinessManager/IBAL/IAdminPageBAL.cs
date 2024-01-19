using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IAdminPageBAL
    {
        public List<AdminPageModel> GetAdminList();
        public AdminPageModel AddAdmin(AdminPageModel admin);
        public void DeleteAdmin(int id);
        public AdminPageModel GetAdminByID(int id);
        public string UpdateAdmin(AdminPageModel model, int Id);
    }
}
