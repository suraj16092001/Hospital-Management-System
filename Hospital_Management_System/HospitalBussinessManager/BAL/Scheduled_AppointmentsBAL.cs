﻿using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Scheduled_AppointmentsBAL : IScheduled_AppointmentsBAL
    {
        IScheduled_AppointmentsDAL _IScheduled_AppointmentsDAL;
        public Scheduled_AppointmentsBAL(IDBManager dBManager)
        {
            _IScheduled_AppointmentsDAL = new Scheduled_AppointmentsDAL(dBManager);
        }

        public List<Requested_AppointmentModel> ScheduledPatientList()
        {
            return _IScheduled_AppointmentsDAL.ScheduledPatientList();
        }
    }
}