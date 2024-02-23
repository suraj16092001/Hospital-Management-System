using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;
namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class AdminDashBoardDAL : IAdminDashBoardDAL
    {
        readonly IDBManager _dBManager;
        public AdminDashBoardDAL(IDBManager dBManager)
        {

            _dBManager = dBManager;

        }

        public AdminAllDataViewModel PopulateCount()
        {
            AdminAllDataViewModel oModel = new AdminAllDataViewModel();
            _dBManager.InitDbCommand("sp_hospital_adminDashbord_Count");

            _dBManager.AddCMDOutParam("@Total_Patient", DbType.Int32,0);
            _dBManager.AddCMDOutParam("@Total_Doctor", DbType.Int32, 0);
            _dBManager.AddCMDOutParam("@Ongoing_Appointments", DbType.Int32,0);
            _dBManager.AddCMDOutParam("@Completed_Appointments", DbType.Int32, 0);

            _dBManager.ExecuteNonQuery();

            oModel.Total_Patient = _dBManager.GetOutParam<Int32>("@Total_Patient");
            oModel.Total_Doctor = _dBManager.GetOutParam<Int32>("@Total_Doctor");
            oModel.Ongoing_Appointments = _dBManager.GetOutParam<Int32>("@Ongoing_Appointments");
            oModel.Completed_Appointments = _dBManager.GetOutParam<Int32>("@Completed_Appointments");

            return oModel;

        }
    }
}
