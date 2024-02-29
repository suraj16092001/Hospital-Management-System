using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IPatientDashBoardDAL
    {
        public Requested_AppointmentModel RequestedPatientAppointment(Requested_AppointmentModel model);
        public Requested_AppointmentModel PopulateEmailandName(int id);
    }
}
