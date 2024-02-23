using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class DoctorAppointmentHistoryBAL : IDoctorAppointmentHistoryBAL
    {
        IDoctorAppointmentHistoryDAL _IDoctorAppointmentHistoryDAL;
        public DoctorAppointmentHistoryBAL(IDBManager dBManager)
        {
            _IDoctorAppointmentHistoryDAL = new DoctorAppointmentHistoryDAL(dBManager);
        }

        public List<Requested_AppointmentModel> PastAppointmentPatientList(Requested_AppointmentModel model)
        {
            return _IDoctorAppointmentHistoryDAL.PastAppointmentPatientList(model);
        }
    }
}
