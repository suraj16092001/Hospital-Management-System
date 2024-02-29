using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;
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

        public Requested_AppointmentModel RequestedPatientAppointment(Requested_AppointmentModel model)
        {
            try
            {
                _dBManager.InitDbCommand("Requested_Appointment");

                _dBManager.AddCMDParam("@p_name", model.name);
                _dBManager.AddCMDParam("@p_email", model.email);
                _dBManager.AddCMDParam("@p_department", model.department);
                _dBManager.AddCMDParam("@p_appointment_date", model.appointment_date);
                _dBManager.AddCMDParam("@p_appointment_time", model.appointment_time);
                _dBManager.AddCMDParam("@p_status_id", model.status_id);
                _dBManager.AddCMDParam("@p_description", model.description);
                _dBManager.AddCMDParam("@p_doctor", model.doctor_id);
                _dBManager.AddCMDParam("@p_patient_id", model.patient_id);
                _dBManager.AddCMDParam("@p_created_by", model.User.created_by);
                _dBManager.AddCMDParam("@p_created_at", model.User.created_at);


                _dBManager.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return model;

        }


        public Requested_AppointmentModel PopulateEmailandName(int id)
        {
            Requested_AppointmentModel oModel = null;
            try
            {
                _dBManager.InitDbCommand("PopulatePatientData");
                _dBManager.AddCMDParam("@p_id", id);
                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    oModel = new Requested_AppointmentModel();
                    oModel.User = new UserModel();
                    
                    oModel.User.id = item["id"].ConvertDBNullToInt();
                    oModel.User.name = item["name"].ConvertDBNullToString();
                    oModel.User.email = item["email"].ConvertDBNullToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return oModel;
        }

    }


}
