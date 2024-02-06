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

        public Requested_AppointmentModel RequestedAppointment(Requested_AppointmentModel model)
        {
            _dBManager.InitDbCommand("Requested_Appointment");

            _dBManager.AddCMDParam("@p_patient_id", model.patient_id);
            _dBManager.AddCMDParam("@p_name", model.name);
            _dBManager.AddCMDParam("@p_email", model.email);
            _dBManager.AddCMDParam("@p_appointment_date", model.appointment_date);
            _dBManager.AddCMDParam("@p_appointment_time", model.appointment_time);
            _dBManager.AddCMDParam("@p_department", model.department);
            _dBManager.AddCMDParam("@p_status", model.status);
            _dBManager.AddCMDParam("@p_description", model.description);


            _dBManager.ExecuteNonQuery();
            return model;

        }
    }
       
  
}
