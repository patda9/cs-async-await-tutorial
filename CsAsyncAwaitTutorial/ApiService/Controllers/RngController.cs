using System;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RngController : Controller
    {
        private readonly ILogger<RngController> _logger;

        public RngController(ILogger<RngController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("HundredThousand")]
        public string RandomHundredThousand()
        {
            Thread.Sleep(1000);

            var randomNumber = new Random().Next(100000, 1000000);

            _logger.LogInformation($"Generated: {randomNumber}");

            return randomNumber.ToString();
        }
    }
}