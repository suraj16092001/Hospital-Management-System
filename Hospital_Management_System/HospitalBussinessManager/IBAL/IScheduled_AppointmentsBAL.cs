using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IScheduled_AppointmentsBAL
    {
       public List<Requested_AppointmentModel> ScheduledPatientList();
    }
}
