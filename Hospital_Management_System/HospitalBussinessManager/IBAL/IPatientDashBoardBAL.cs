using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IPatientDashBoardBAL
    {
        public Requested_AppointmentModel RequestedAppointment(Requested_AppointmentModel model);
    }
}
