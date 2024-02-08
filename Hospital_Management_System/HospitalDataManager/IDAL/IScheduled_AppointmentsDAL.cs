using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IScheduled_AppointmentsDAL
    {
        public List<Requested_AppointmentModel> ScheduledPatientList(Requested_AppointmentModel model);
     
    }
}
