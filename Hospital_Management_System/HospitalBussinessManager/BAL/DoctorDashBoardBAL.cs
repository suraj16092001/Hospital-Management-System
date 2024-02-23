using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class DoctorDashBoardBAL : IDoctorDashBoardBAL
    {
        IDoctorDashBoardDAL _IDoctorDashBoardDAL;
        public DoctorDashBoardBAL(IDBManager dBManager)
        {
            _IDoctorDashBoardDAL = new DoctorDashBoardDAL(dBManager);
        }

        public AdminAllDataViewModel PopulateCount(AdminAllDataViewModel Model)
        {
            return _IDoctorDashBoardDAL.PopulateCount(Model);
        }
    }
}
