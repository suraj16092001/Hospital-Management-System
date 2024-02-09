using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class PatientDashBoardBAL : IPatientDashBoardBAL
    {
        IPatientDashBoardDAL _IPatientDashBoardDAL;

        public PatientDashBoardBAL(IDBManager dBManager)
        {
            _IPatientDashBoardDAL = new PatientDashBoardDAL(dBManager);
        }

        public Requested_AppointmentModel RequestedAppointment(Requested_AppointmentModel model)
        {
            model.status_id = 1;
            return _IPatientDashBoardDAL.RequestedAppointment(model);
        }
    }
}
