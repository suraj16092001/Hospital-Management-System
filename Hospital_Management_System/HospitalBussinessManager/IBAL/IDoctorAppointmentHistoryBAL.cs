using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IDoctorAppointmentHistoryBAL
    {
        public List<Requested_AppointmentModel> PastAppointmentPatientList(Requested_AppointmentModel model);
    }
}
