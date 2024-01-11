using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class Admin_DoctorPageController:Controller
    {
        public IActionResult Admin_Doctor()
        {
            return View();
        }
    }
}
