using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IDoctorAppointmentHistoryDAL
    {
        public List<Requested_AppointmentModel> PastAppointmentPatientList(Requested_AppointmentModel model);
    }
}
