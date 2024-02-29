using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IPatientDashBoardBAL
    {
        public Task<string> RequestedAppointment(Requested_AppointmentModel model);
        public Requested_AppointmentModel PopulateEmailandName(int id);
    }
}
