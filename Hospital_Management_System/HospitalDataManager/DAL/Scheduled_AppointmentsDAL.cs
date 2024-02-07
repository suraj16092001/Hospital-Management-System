﻿using CRUDoperation.CommonCode;
using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using System.Data;

namespace Hospital_Management_System.HospitalDataManager.DAL
{
    public class Scheduled_AppointmentsDAL : IScheduled_AppointmentsDAL
    {
        readonly IDBManager _dBManager;

        public Scheduled_AppointmentsDAL(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public List<Requested_AppointmentModel> ScheduledPatientList()
        {
            List<Requested_AppointmentModel> ScheduledPatientList = new List<Requested_AppointmentModel>();
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
                oModel.doctor_name = item["doctor_name"].ConvertDBNullToString();

                ScheduledPatientList.Add(oModel);
            }

            return ScheduledPatientList;
        }
    }
}