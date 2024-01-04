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