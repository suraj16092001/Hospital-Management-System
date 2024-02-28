using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Collections.Generic;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class Requested_appointmentsDAL : IRequested_appointmentsDAL
    {
        readonly IDBManager _dBManager;
        public Requested_appointmentsDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public List<Requested_AppointmentModel> RequestedPatientList()
        {
            List<Requested_AppointmentModel> RequestedPatientList = new List<Requested_AppointmentModel>();
            try
            {

                _dBManager.InitDbCommand("GetRequestedPatientList");

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

                    RequestedPatientList.Add(oModel);

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return RequestedPatientList;
        }


        public Requested_AppointmentModel GetRequested_Appointment(int id)
        {
            Requested_AppointmentModel oModel = null;
            try
            {
                _dBManager.InitDbCommand("GetRequested_Appointment");
                _dBManager.AddCMDParam("@p_id", id);
                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    oModel = new Requested_AppointmentModel();

                    oModel.User = new UserModel();
                    oModel.statusModel = new Appointment_StatusModel();

                    oModel.id = item["id"].ConvertDBNullToInt();
                    oModel.name = item["name"].ConvertDBNullToString();
                    oModel.email = item["email"].ConvertDBNullToString();
                    oModel.department = item["department"].ConvertDBNullToString();
                    oModel.description = item["description"].ConvertDBNullToString();
                    oModel.User.name = item["Doctor_name"].ConvertDBNullToString(); // Fetch Doctor_name
                    oModel.appointment_date = item["appointment_date"].ConvertDBNullToString();
                    oModel.appointment_time = item["appointment_time"].ConvertDBNullToString();
                    oModel.statusModel.Status = item["status"].ConvertDBNullToString(); // Fetch status
                    oModel.status_id = item["status_id"].ConvertDBNullToInt(); // Fetch status id

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return oModel;
        }

        public Requested_AppointmentModel UpdateStatus(Requested_AppointmentModel model)
        {
            try
            {
                _dBManager.InitDbCommand("UpdateStatus");
                _dBManager.AddCMDParam("@p_id", model.id);
                _dBManager.AddCMDParam("@p_name", model.name);
                _dBManager.AddCMDParam("@p_email", model.email);
                _dBManager.AddCMDParam("@p_appointment_date", model.appointment_date);
                _dBManager.AddCMDParam("@p_appointment_time", model.appointment_time);
                _dBManager.AddCMDParam("@p_department", model.department);
                _dBManager.AddCMDParam("@p_description", model.description);
                _dBManager.AddCMDParam("@p_status_id", model.status_id);

                _dBManager.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());            
            }
            return model;
        }

        public List<Appointment_StatusModel> GetStatus()
        {
            List<Appointment_StatusModel> StatusList = new List<Appointment_StatusModel>();
            try
            {
                _dBManager.InitDbCommand("StatusList");
                DataSet ds = _dBManager.ExecuteDataSet();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Appointment_StatusModel oModel = new Appointment_StatusModel();
                    oModel.Status_id = item["status_id"].ConvertDBNullToInt();
                    oModel.Status = item["status"].ConvertDBNullToString();

                    StatusList.Add(oModel);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return StatusList;

        }

        public Requested_AppointmentModel PopulateEmail(int id)
        {
            Requested_AppointmentModel oModel = null;
            try
            {
                _dBManager.InitDbCommand("GetRequested_Appointment");
                _dBManager.AddCMDParam("@p_id", id);
                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    oModel = new Requested_AppointmentModel();

                    oModel.id = item["id"].ConvertDBNullToInt();
                    oModel.name = item["name"].ConvertDBNullToString();
                    oModel.email = item["email"].ConvertDBNullToString();

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return oModel;
        }
    }
}
