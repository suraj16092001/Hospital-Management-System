using Hospital_Management_System.HospitalBussinessManager.BAL;
using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Hospital_Management_System.Extension
{
    public static class DataManager
    {
        public static IServiceCollection AddAppSetting(this IServiceCollection services)
        {
            services.AddScoped<IDBManager>(AddDBManager);
            services.AddScoped<ILoginBAL, LoginBAL>();
            services.AddScoped<IAdmin_PatientPageBAL, Admin_PatientPageBAL>();
            services.AddScoped<IAdmin_DoctorPageBAL, Admin_DoctorPageBAL>();
            services.AddScoped<IAdminPageBAL,AdminPageBAL>();
            services.AddScoped<IPatientDashBoardBAL,PatientDashBoardBAL>();
            services.AddScoped<IRequested_appointmentsBAL, Requested_appointmentsBAL>();
            services.AddScoped<IScheduled_AppointmentsBAL, Scheduled_AppointmentsBAL>();
            services.AddScoped<ICompletedAppointmentHistoryBAL, CompletedAppointmentHistoryBAL>();
            services.AddScoped<IDoctorAppointmentHistoryBAL, DoctorAppointmentHistoryBAL>();
            services.AddScoped<IAdminDashBoardBAL, AdminDashBoardBAL>();
            services.AddScoped<IDoctorDashBoardBAL, DoctorDashBoardBAL>();
            services.AddScoped<IAdminProfileBAL, AdminProfileBAL>();
            services.AddScoped<IDoctorProfileBAL, DoctorProfileBAL>();
            services.AddTransient<IEmailSenderBAL, EmailSenderBAL>();

            return services;
        }
        internal static IDBManager AddDBManager(IServiceProvider serviceProvider)
        {
            IConfiguration Configuration = serviceProvider.GetRequiredService<IConfiguration>();

            string dbconstr = Configuration.GetConnectionString("DefaultConnection");
            string salt = Configuration["salt"];
            return GetDBManager(dbconstr, salt);


        }
        public static IDBManager GetDBManager(string connectionString,string salt)
        {
            DbConnection dbconn = new MySqlConnection(connectionString);
            return new DBManager(dbconn,salt);
        }
    }
}