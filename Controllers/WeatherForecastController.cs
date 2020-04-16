using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MailClientFluentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMailClient mailClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMailClient mailClient)
        {
            _logger = logger;
            this.mailClient = mailClient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            mailClient.SetLogger(_logger)
                .PutMailToMailingList("lukasz.tomalczyk@ubs.com", "wirak", "ode mnie")
                .SendEmailToAllRecipients();
            return Ok();
        }
    }
}
