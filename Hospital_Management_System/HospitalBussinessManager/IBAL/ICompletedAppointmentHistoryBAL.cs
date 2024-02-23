using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface ICompletedAppointmentHistoryBAL
    {
        List<Requested_AppointmentModel> CompletedAppointmentPatientList();
    }
}
