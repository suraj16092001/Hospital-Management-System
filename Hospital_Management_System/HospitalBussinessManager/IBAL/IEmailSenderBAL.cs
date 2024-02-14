namespace Hospital_Management_System.HospitalBussinessManager.IBAL
{
    public interface IEmailSenderBAL
    {
        Task<bool> EmailSendAsync(string email, string Subject, string message);
    }
}
