
using Hospital_Management_System.HospitalDataManager.DAL;
using System.Data;
namespace Hospital_Management_System.HospitalDataManager.IDAL
{
    public interface IDBManager
    {
        HospitalDataManager.DAL.DBManager InitDbCommand(string cmd);
        HospitalDataManager.DAL.DBManager InitDbCommand(string cmd, CommandType cmdtype);
        HospitalDataManager.DAL.DBManager AddCMDParam(string parametername, object value);
        HospitalDataManager.DAL.DBManager AddCMDParam(string parametername, object value, DbType dbtype);
        HospitalDataManager.DAL.DBManager AddCMDOutParam(string parametername, DbType dbtype, int iSize = 0);

        T GetOutParam<T>(string paramname);
        DataTable ExecuteDataTable();
        DataSet ExecuteDataSet();

        object? ExecuteScalar();

        Task<object?> ExecuteScalarAsync();
        int ExecuteNonQuery();
        Task<int> ExecuteNonQueryAsync();
        HospitalDataManager.DAL.DBManager InitDbCommandText(string cmd);

    }
}