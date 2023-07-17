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

        [HttpGet(Name = "GetMuffins")]
        public IEnumerable<Muffin> Get()
        {
            return _muffinServerService.ListMuffins().Result;
        }

        [HttpPut(Name = "updateMuffins")]
        public IEnumerable<Muffin> Put([FromBody] Muffin[] update)
        {
            var response = _muffinServerService.UpdateOrderedMuffins(update).Result;
            return update.ToList();
        }
    }
}