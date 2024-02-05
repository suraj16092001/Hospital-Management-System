using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class PatientDashBoardDAL:IPatientDashBoardDAL
    {
        readonly IDBManager _dBManager;
        public PatientDashBoardDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public RequestedCombinedViewModel RequestedAppointment(RequestedCombinedViewModel model)
        {
            _dBManager.InitDbCommand("insertRequestAppointment");

            _dBManager.AddCMDParam("@p_id", model.User.id);
            _dBManager.AddCMDParam("@p_id", model.Appointment.name);
            _dBManager.AddCMDParam("@p_id", model.Appointment.email);
            _dBManager.AddCMDParam("@p_id", model.Appointment.appointment_date);
            _dBManager.AddCMDParam("@p_id", model.Appointment.appointment_time);
            _dBManager.AddCMDParam("@p_id", model.Appointment.department);
            _dBManager.AddCMDParam("@p_id", model.Appointment.status);
            _dBManager.AddCMDParam("@p_id", model.Appointment.description);
            return model;

        }
    }
       
  
}
