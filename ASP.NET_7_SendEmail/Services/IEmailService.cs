using ASP.NET_7_SendEmail.Models;

namespace ASP.NET_7_SendEmail.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
