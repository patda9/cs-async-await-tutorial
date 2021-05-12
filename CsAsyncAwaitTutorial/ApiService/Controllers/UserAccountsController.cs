using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLib.Models;

namespace ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountsController : Controller
    {
        private readonly List<UserAccount> _userAccounts = new()
        {
            new UserAccount("admin", "admin"),
            new UserAccount("devuser", "devuser"),
            new UserAccount("user", "user")
        };

        private readonly ILogger<UserAccountsController> _logger;

        public UserAccountsController(ILogger<UserAccountsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserAccount> Get()
        {
            Thread.Sleep(5000);

            return _userAccounts;
        }
    }
}