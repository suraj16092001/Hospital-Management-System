using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface ICompletedAppointmentHistoryDAL
    {
        public List<Requested_AppointmentModel> CompletedAppointmentPatientList();
    }
}
