using ClientApp.Dto;
using ClientApp.Interface;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("CreateRunningJob")]
        public IActionResult CreateRunningJob([FromQuery] EmailDto request)
        {
            RecurringJob.AddOrUpdate("my-recurring-job", () => _emailSender.SendEmail(request), Cron.HourInterval(6));
            return Ok();
        }

    }
}
