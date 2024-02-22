using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Scheduled_AppointmentsBAL : IScheduled_AppointmentsBAL
    {
        IScheduled_AppointmentsDAL _IScheduled_AppointmentsDAL;
        //IPatientDashBoardDAL _IPatientDashBoardDAL;
        IRequested_appointmentsDAL  _IRequested_appointmentsDAL;
 
        public Scheduled_AppointmentsBAL(IDBManager dBManager)
        {
            _IScheduled_AppointmentsDAL = new Scheduled_AppointmentsDAL(dBManager);
            //_IPatientDashBoardDAL = new PatientDashBoardDAL(dBManager);
            _IRequested_appointmentsDAL = new Requested_appointmentsDAL(dBManager);
        }

        public List<Requested_AppointmentModel> ScheduledPatientList(Requested_AppointmentModel model)
        {
                return _IScheduled_AppointmentsDAL.ScheduledPatientList(model);
        }

        public Requested_AppointmentModel GetScheduledAppointments(int id)
        {
            return _IScheduled_AppointmentsDAL.GetScheduledAppointments(id);
        }

        public List<Appointment_StatusModel> GetStatusForDoctor()
        {
            return _IScheduled_AppointmentsDAL.GetStatusForDoctor();

        }

        public Requested_AppointmentModel UpdateStatusByEmailFromDoctor(Requested_AppointmentModel model)
        {

            return _IRequested_appointmentsDAL.UpdateStatus(model);
        }
    }
}
