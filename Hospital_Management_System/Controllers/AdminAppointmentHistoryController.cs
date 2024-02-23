using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class AdminAppointmentHistoryController : Controller
    {
        ICompletedAppointmentHistoryBAL _ICompletedAppointmentHistoryBAL;
        public AdminAppointmentHistoryController(ICompletedAppointmentHistoryBAL completedAppointmentHistoryBAL)
        {
            _ICompletedAppointmentHistoryBAL = completedAppointmentHistoryBAL;
        }
        public IActionResult AdminAppointmentHistory()
        {
            return View();
        }

        public IActionResult AdminAppointmentHistoryList()
        {
            return Json(_ICompletedAppointmentHistoryBAL.CompletedAppointmentPatientList());
        }

    }
}
