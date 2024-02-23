namespace Hospital_Management_System.Models
{
	public class AdminAllDataViewModel
	{
		public AdminPageModel AdminPage { get; set; }
		public UserModel User { get; set; }

		public int id { get; set; }
        public int Total_Patient {  get; set; }
		public int Total_Doctor { get; set;}
		public int Ongoing_Appointments { get; set;}
		public int Completed_Appointments { get; set;}

    }
}
