using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ASP.NET_7_SendEmail.Services;
using ASP.NET_7_SendEmail.Models;

namespace ASP.NET_7_SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // Method to Send Email
        [HttpPost]
        public IActionResult SendEmail(EmailDTO request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
