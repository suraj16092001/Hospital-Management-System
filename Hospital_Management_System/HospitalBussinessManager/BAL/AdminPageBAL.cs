using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class AdminPageBAL:IAdminPageBAL
    {
        IAdminPageDAL _IAdminPageDAL;
        public AdminPageBAL(IDBManager dBManager)
        {
            _IAdminPageDAL = new AdminPageDAL(dBManager);
        }

        List<AdminPageModel> IAdminPageBAL.GetAdminList()
        {
            return _IAdminPageDAL.GetAdminList();
        }

        public AdminPageModel AddAdmin(AdminPageModel model)
        {
            return _IAdminPageDAL.AddAdmin(model);
        }

        public void DeleteAdmin(int id)
        {
            _IAdminPageDAL.DeleteAdmin(id);

        }
        public AdminPageModel GetAdminByID(int id)
        {
            return _IAdminPageDAL.GetAdminByID(id);
        }

        public string UpdateAdmin(AdminPageModel model, int Id)
        {
            _IAdminPageDAL.UpdateAdmin(model, Id);
            return "Success";
        }


    }
}
