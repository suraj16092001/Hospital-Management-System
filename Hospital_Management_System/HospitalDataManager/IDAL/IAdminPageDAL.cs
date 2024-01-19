using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IAdminPageDAL
    {
        public List<AdminPageModel> GetAdminList();
        public AdminPageModel AddAdmin(AdminPageModel admin);

        public void DeleteAdmin(int id);
        public AdminPageModel GetAdminByID(int id);

        public AdminPageModel UpdateAdmin(AdminPageModel admin, int Id);
    }
}
