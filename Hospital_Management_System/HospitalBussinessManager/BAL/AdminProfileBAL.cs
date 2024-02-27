using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class AdminProfileBAL : IAdminProfileBAL
    {
        IAdminProfileDAL _IAdminProfileDAL;
        ILoginDAL _ILoginDAL;
        public AdminProfileBAL(IDBManager dBManager)
        {
            _IAdminProfileDAL = new AdminProfileDAL(dBManager);
            _ILoginDAL = new LoginDAL(dBManager);
        }

        public AdminAllDataViewModel GetAdmin_Profile(int id)
        {
            return _IAdminProfileDAL.GetAdmin_Profile(id);
        }

        public string UpdateAdmin(AdminAllDataViewModel model)
        {
            bool emailExists = _ILoginDAL.CheckEmailExistence(model.User.email, model.User.id);

            if (emailExists)
            {
                return "exists";
            }

            _IAdminProfileDAL.UpdateAdmin(model);
            return "success";

        }
    }
}
