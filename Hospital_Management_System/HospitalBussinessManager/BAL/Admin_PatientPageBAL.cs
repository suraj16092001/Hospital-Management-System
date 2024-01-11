using Hospital_Management_System.HospitalBussinessManager.IBAL;
using Hospital_Management_System.HospitalDataManager.IDAL;

namespace Hospital_Management_System.HospitalBussinessManager.BAL
{
    public class Admin_PatientPageBAL:IAdmin_PatientPageBAL
    {
        IAdmin_PatientPageBAL _PatientPageBAL;

        public Admin_PatientPageBAL(IDBManager dBManager)
        {

            //_PatientPageBAL = new dBManager;
        }
    }
}
