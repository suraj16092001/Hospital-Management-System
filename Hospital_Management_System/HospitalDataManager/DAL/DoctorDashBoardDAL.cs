using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class DoctorDashBoardDAL : IDoctorDashBoardDAL
    {
        readonly IDBManager _dBManager;
        public DoctorDashBoardDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public AdminAllDataViewModel PopulateCount(AdminAllDataViewModel oModel)
        {
            try
            {
                _dBManager.InitDbCommand("sp_hospital_doctorDashbord_Count");
                _dBManager.AddCMDParam("@p_id", oModel.id);

                _dBManager.AddCMDOutParam("@Ongoing_Appointments", DbType.Int32, 0);
                _dBManager.AddCMDOutParam("@Completed_Appointments", DbType.Int32, 0);

                _dBManager.ExecuteNonQuery();


                oModel.Ongoing_Appointments = _dBManager.GetOutParam<Int32>("@Ongoing_Appointments");
                oModel.Completed_Appointments = _dBManager.GetOutParam<Int32>("@Completed_Appointments");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return oModel;

        }
    }
}
