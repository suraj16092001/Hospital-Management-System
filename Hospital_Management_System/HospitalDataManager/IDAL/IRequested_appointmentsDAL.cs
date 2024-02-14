using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IRequested_appointmentsDAL
    {
        List<Requested_AppointmentModel> RequestedPatientList();
        public Requested_AppointmentModel GetRequested_Appointment(int id);
        public Requested_AppointmentModel UpdateStatus(Requested_AppointmentModel model);
        public List<Appointment_StatusModel> GetStatus();
        public Requested_AppointmentModel PopulateEmail(int id);
    }
}
