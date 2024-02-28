using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class CompletedAppointmentHistoryDAL : ICompletedAppointmentHistoryDAL
    {
        readonly IDBManager _dBManager;
        public CompletedAppointmentHistoryDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public List<Requested_AppointmentModel> CompletedAppointmentPatientList()
        {
            List<Requested_AppointmentModel> appointmentHistory = new List<Requested_AppointmentModel>();
            try
            {
                _dBManager.InitDbCommand("sp_hospital_CompletedAppointmentHistory_PatientList");
                DataSet ds = _dBManager.ExecuteDataSet();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Requested_AppointmentModel oModel = new Requested_AppointmentModel();
                    oModel.statusModel = new Appointment_StatusModel();
                    oModel.id = item["id"].ConvertDBNullToInt();
                    oModel.name = item["name"].ConvertDBNullToString();
                    oModel.email = item["email"].ConvertDBNullToString();
                    oModel.appointment_date = item["appointment_date"].ConvertDBNullToString();
                    oModel.appointment_time = item["appointment_time"].ConvertDBNullToString();
                    oModel.description = item["description"].ConvertDBNullToString();
                    oModel.department = item["department"].ConvertDBNullToString();
                    oModel.statusModel.Status = item["status"].ConvertDBNullToString();
                    oModel.patient_id = item["patient_id"].ConvertDBNullToInt();

                    appointmentHistory.Add(oModel);

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return appointmentHistory;
        }
    }
}

    

