using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IPatientDashBoardDAL
    {
        public RequestedCombinedViewModel RequestedAppointment(RequestedCombinedViewModel model);
    }
}
