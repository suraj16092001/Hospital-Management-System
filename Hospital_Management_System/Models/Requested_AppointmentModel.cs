using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Requested_AppointmentModel
    {
        public int id { get; set; }
        public string name { get; set;}
        public string email { get; set;}

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY/MM/DD}")]
        public string appointment_date { get; set;}

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm:ss A}")]
        public string appointment_time { get; set;}
        public string department { get; set;}
        public string status { get; set;}
        public string description { get; set;}
        public string doctor_name { get; set; }
        public int patient_id { get; set;}
    }
}
