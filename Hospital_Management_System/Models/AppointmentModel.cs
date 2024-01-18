using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hospital_Management_System.Models
{
    public class AppointmentModel
    {
        public int id { get; set; }

        public string disease { get; set; }
        public string doctor { get; set; }

        //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:MM/dd/yyyy}")]
        public DateOnly appointment_date { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:mm}")]
        //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public TimeOnly appointment_time { get; set; }

    }
}
