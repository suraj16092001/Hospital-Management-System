using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IPatientDashBoardBAL
    {
        public RequestedCombinedViewModel RequestedAppointment(RequestedCombinedViewModel model);
    }
}
