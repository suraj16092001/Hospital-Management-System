using Hospital_Management_System.HospitalDataManager.IDAL;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class CompletedAppointmentHistoryBAL : HospitalDataManager.IDAL.ICompletedAppointmentHistoryDAL
    {
        ICompletedAppointmentHistoryDAL _ICompletedAppointmentHistoryDAL;
        public CompletedAppointmentHistoryBAL(ICompletedAppointmentHistoryDAL completedAppointmentHistoryDAL)
        {
            _ICompletedAppointmentHistoryDAL = completedAppointmentHistoryDAL;
        }
    }
}
