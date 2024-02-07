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

            _dBManager.InitDbCommand("GetRequestedPatientList");

            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Requested_AppointmentModel oModel = new Requested_AppointmentModel();

                oModel.id = item["id"].ConvertDBNullToInt();
                oModel.name = item["name"].ConvertDBNullToString();
                oModel.email = item["email"].ConvertDBNullToString();
                oModel.appointment_date = item["appointment_date"].ConvertDBNullToString();
                oModel.appointment_time = item["appointment_time"].ConvertDBNullToString();
                oModel.description = item["description"].ConvertDBNullToString();
                oModel.department = item["department"].ConvertDBNullToString();
                oModel.status = item["status"].ConvertDBNullToString();
                oModel.patient_id = item["patient_id"].ConvertDBNullToInt();

                RequestedPatientList.Add(oModel);

            }

            return RequestedPatientList;
        }


        public Requested_AppointmentModel GetRequested_Appointment(int id)
        {
            Requested_AppointmentModel oModel = null;
            _dBManager.InitDbCommand("GetRequested_Appointment");
            _dBManager.AddCMDParam("@p_id", id);
            DataSet ds = _dBManager.ExecuteDataSet();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                oModel = new Requested_AppointmentModel();
                oModel.id = item["id"].ConvertDBNullToInt();
                oModel.name = item["name"].ConvertDBNullToString();
                oModel.email = item["email"].ConvertDBNullToString();
                oModel.department = item["department"].ConvertDBNullToString();
                oModel.doctor_name = item["doctor_name"].ConvertDBNullToString();
                oModel.appointment_date = item["appointment_date"].ConvertDBNullToString();
                oModel.appointment_time = item["appointment_time"].ConvertDBNullToString();
                oModel.status = item["status"].ConvertDBNullToString();

            }
            return oModel;
        }

        public Requested_AppointmentModel UpdateStatus(Requested_AppointmentModel model)
        {
            _dBManager.InitDbCommand("UpdateStatus");
            _dBManager.AddCMDParam("@p_id", model.id);
            _dBManager.AddCMDParam("@p_name", model.name);
            _dBManager.AddCMDParam("@p_email", model.email);
            _dBManager.AddCMDParam("@p_appointment_date", model.appointment_date);
            _dBManager.AddCMDParam("@p_appointment_time", model.appointment_time);
            _dBManager.AddCMDParam("@p_department", model.department);
            _dBManager.AddCMDParam("@p_status", model.status);

            _dBManager.ExecuteNonQuery();
            return model;
        }
    }
}
