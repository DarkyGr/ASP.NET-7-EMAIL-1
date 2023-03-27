using ASP.NET_7_SendEmail.Models;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace ASP.NET_7_SendEmail.Services
{
    public class EmailService : IEmailService
    {
        // Adding the configuration of appsettings
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();

            // From
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value));

            // To
            email.To.Add(MailboxAddress.Parse(request.To));

            // Subject
            email.Subject = request.Subject;

            // Body
            email.Body = new TextPart(TextFormat.Html) { 
                Text = request.Body
            };

            // Configuration SMTP
            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
            );

            // Adding Autenticate of the email
            smtp.Authenticate(_configuration.GetSection("Email:UserName").Value, _configuration.GetSection("Email:Password").Value);

            // Send Emial
            smtp.Send(email);

            // Disconect of Server
            smtp.Disconnect(true);
        }
    }
}
