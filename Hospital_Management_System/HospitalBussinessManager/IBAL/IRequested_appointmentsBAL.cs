using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IRequested_appointmentsBAL
    {
        List<Requested_AppointmentModel> RequestedPatientList();
        public Requested_AppointmentModel GetRequested_Appointment(int id);
        public Requested_AppointmentModel UpdateStatus(Requested_AppointmentModel model);
    }
}
