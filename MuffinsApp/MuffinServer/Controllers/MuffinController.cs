using Microsoft.AspNetCore.Mvc;
using MuffinServer.Models;
namespace MuffinServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MuffinController : ControllerBase
    {

        private MuffinServer.Services.MuffinsService _muffinServerService;
        private readonly ILogger<MuffinController> _logger;

        public MuffinController(ILogger<MuffinController> logger)
        {
            _logger = logger;
            _muffinServerService = new Services.MuffinsService();
        }
        
        [HttpGet(Name = "GetUser")]
        public User Get()
        {
            return new MuffinServer.Models.User
            {
            
            };
        }


        [HttpPut(Name = "addUser")]
        public bool addUser([FromBody] MuffinServer.Models.NewUser user)
        {
            var response = _muffinServerService.AddUser(user).Result;
            return response;
        }

        [HttpPost(Name = "addProfile")]
        public bool addProfile([FromBody] MuffinServer.Models.Profile update)
        {
            var response = _muffinServerService.AddProfile(update).Result;
            return response;
        }
    }
}
