using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IScheduled_AppointmentsDAL
    {
        public List<Requested_AppointmentModel> ScheduledPatientList(Requested_AppointmentModel model);
        public Requested_AppointmentModel GetScheduledAppointments(int id);
        public List<Appointment_StatusModel> GetStatusForDoctor();

        //public Requested_AppointmentModel UpdateDoctorSideStatus(Requested_AppointmentModel model);
    }
}
