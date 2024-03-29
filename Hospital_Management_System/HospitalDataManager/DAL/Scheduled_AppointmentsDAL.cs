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

        public List<Requested_AppointmentModel> ScheduledPatientList(Requested_AppointmentModel model)
        {
            List<Requested_AppointmentModel> ScheduledPatientList = new List<Requested_AppointmentModel>();
            try
            {
                _dBManager.InitDbCommand("Scheduled_appointmentListBy_ID");
                _dBManager.AddCMDParam("p_Doctor_id", model.doctor_id);
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
                    oModel.status_id = item["status_id"].ConvertDBNullToInt();
                    oModel.patient_id = item["patient_id"].ConvertDBNullToInt();

                    ScheduledPatientList.Add(oModel);
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ScheduledPatientList;
        }

        public Requested_AppointmentModel GetScheduledAppointments(int id)
        {
            Requested_AppointmentModel oModel = null;
            try
            {
                _dBManager.InitDbCommand("GetRequested_Appointment");//same sp use as Requested_appointments/GetRequested_Appointment()
                _dBManager.AddCMDParam("@p_id", id);
                DataSet ds = _dBManager.ExecuteDataSet();

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    oModel = new Requested_AppointmentModel();

                    oModel.statusModel = new Appointment_StatusModel();

                    oModel.id = item["id"].ConvertDBNullToInt();
                    oModel.name = item["name"].ConvertDBNullToString();
                    oModel.email = item["email"].ConvertDBNullToString();
                    oModel.appointment_date = item["appointment_date"].ConvertDBNullToString();
                    oModel.appointment_time = item["appointment_time"].ConvertDBNullToString();
                    oModel.description = item["description"].ConvertDBNullToString();
                    oModel.department = item["department"].ConvertDBNullToString();
                    oModel.status_id = item["status_id"].ConvertDBNullToInt();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return oModel;
        }

        public List<Appointment_StatusModel> GetStatusForDoctor()
        {
            List<Appointment_StatusModel> StatusList = new List<Appointment_StatusModel>();
            try
            {
                _dBManager.InitDbCommand("sp_hospital_scheduledAppointments_GetStatusForDoctor");
                DataSet ds = _dBManager.ExecuteDataSet();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Appointment_StatusModel oModel = new Appointment_StatusModel();
                    oModel.Status_id = item["status_id"].ConvertDBNullToInt();
                    oModel.Status = item["status"].ConvertDBNullToString();

                    StatusList.Add(oModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return StatusList;

        }

        


    }
}
