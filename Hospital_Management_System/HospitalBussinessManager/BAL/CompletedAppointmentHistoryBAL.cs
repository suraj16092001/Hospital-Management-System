using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class CompletedAppointmentHistoryBAL : ICompletedAppointmentHistoryBAL
    {
        ICompletedAppointmentHistoryDAL _ICompletedAppointmentHistoryDAL;
        public CompletedAppointmentHistoryBAL(IDBManager dBManager)
        {
            _ICompletedAppointmentHistoryDAL = new CompletedAppointmentHistoryDAL(dBManager);
        }

        public List<Requested_AppointmentModel> CompletedAppointmentPatientList()
        {
           return _ICompletedAppointmentHistoryDAL.CompletedAppointmentPatientList();
        }
    }


   
}
