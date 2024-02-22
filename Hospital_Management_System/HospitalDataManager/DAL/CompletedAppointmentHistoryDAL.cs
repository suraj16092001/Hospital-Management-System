using Hospital_Management_System.HospitalDataManager.IDAL;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class CompletedAppointmentHistoryDAL : ICompletedAppointmentHistoryDAL
    {
        readonly IDBManager _dBManager;
        public CompletedAppointmentHistoryDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }
    }
}
