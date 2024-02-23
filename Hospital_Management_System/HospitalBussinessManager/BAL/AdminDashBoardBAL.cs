using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class AdminDashBoardBAL : IAdminDashBoardBAL
    {
        IAdminDashBoardDAL _IAdminDashBoardDAL;
        public AdminDashBoardBAL(IDBManager dBManager)
        {
            _IAdminDashBoardDAL = new AdminDashBoardDAL(dBManager);
        }

        public AdminAllDataViewModel PopulateCount()
        {
            return _IAdminDashBoardDAL.PopulateCount();
        }
    }
}
