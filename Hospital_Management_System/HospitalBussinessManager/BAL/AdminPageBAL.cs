using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class AdminPageBAL:IAdminPageBAL
    {
        IAdminPageDAL _IAdminPageDAL;
        ILoginDAL _ILoginDAL;
        public AdminPageBAL(IDBManager dBManager)
        {
            _IAdminPageDAL = new AdminPageDAL(dBManager);
            _ILoginDAL = new LoginDAL(dBManager);
        }

        List<AdminAllDataViewModel> IAdminPageBAL.GetAdminList()
        {
            return _IAdminPageDAL.GetAdminList();
        }

        public string AddAdmin(AdminAllDataViewModel model)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(model.User.email,model.User.id);

            if (emailExists)
            {
                return "exists";
            }
            model.User.role = 1;
            _IAdminPageDAL.AddAdmin(model);
            return "success";
        }

        public void DeleteAdmin(int id)
        {
            _IAdminPageDAL.DeleteAdmin(id);

        }
        public AdminAllDataViewModel GetAdminByID(int id)
        {
            return _IAdminPageDAL.GetAdminByID(id);
        }

        public string UpdateAdmin(AdminAllDataViewModel model)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(model.User.email, model.User.id);

            if (emailExists)
            {
                return "exists";
            }

             _IAdminPageDAL.UpdateAdmin(model);
            return "success";

        }


    }
}
