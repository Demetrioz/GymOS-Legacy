using GymOS.DataModel.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymOS.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        private ILogger<AccountController> Logger { get; set; }
        private SignInManager<GymOSUser> SignInManager { get; set; }
        private UserManager<GymOSUser> UserManager { get; set; }


        public AccountController(
            ILogger<AccountController> logger, 
            SignInManager<GymOSUser> signInManager,
            UserManager<GymOSUser> userManager
        )
        {
            Logger = logger;
            SignInManager = signInManager;
            UserManager = userManager;
        }

        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "yay!";
        }

        [Authorize]
        [HttpGet]
        [Route("Test2")]
        public string TestTwo()
        {
            return "woot!";
        }
    }
}
