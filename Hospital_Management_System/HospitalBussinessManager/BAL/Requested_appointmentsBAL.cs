using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Requested_appointmentsBAL : IRequested_appointmentsBAL
    {
        IRequested_appointmentsDAL _IRequested_appointmentsDAL;
        public Requested_appointmentsBAL(IDBManager dBManager)
        {
            _IRequested_appointmentsDAL = new Requested_appointmentsDAL(dBManager);
        }

        List<Requested_AppointmentModel> IRequested_appointmentsBAL.RequestedPatientList()
        {
            return _IRequested_appointmentsDAL.RequestedPatientList();
        }

        public Requested_AppointmentModel GetRequested_Appointment(int id)
        {
            return _IRequested_appointmentsDAL.GetRequested_Appointment(id);
        }

        public Requested_AppointmentModel UpdateStatus(Requested_AppointmentModel model)
        {
            return _IRequested_appointmentsDAL.UpdateStatus(model);
        }

        public List<Appointment_StatusModel> GetStatus()
        {
            return _IRequested_appointmentsDAL.GetStatus();
        }

        public Requested_AppointmentModel PopulateEmail(int id)
        {
            return _IRequested_appointmentsDAL.PopulateEmail(id);
        }
    }
}
