using Microsoft.AspNetCore.Mvc;
using ProfileServer.Models;
namespace ProfileServer.Controllers
{
    [ApiController]
    [Route("api/userProfiles")]
    public class ProfilesController : ControllerBase
    {

        private ProfileServer.Services.MuffinsService _profileServerService;
        private readonly ILogger<ProfilesController> _logger;

        public ProfilesController(ILogger<ProfilesController> logger)
        {
            _logger = logger;
            _profileServerService = new Services.MuffinsService();
        }

        [HttpPost("addUser")]
        public bool addUser([FromBody] ProfileServer.Models.CreateNewUserRequest user)
        {
            var response = _profileServerService.AddUser(user).Result;
            return response;
        }
        [HttpPost("addProfile")]
        public bool addProfile([FromBody] ProfileServer.Models.Profile update)
        {
            var response = _profileServerService.AddProfile(update).Result;
            return response;
        }

        [HttpPut("updateProfile")]
        public bool updateProfile([FromBody] ProfileServer.Models.UpdateProfileRequest update)
        {
            var response = _profileServerService.UpdateProfile(update).Result;
            return response;
        }

        [HttpPut("updateUserProfiles")]
        public bool updateUserProfiles([FromBody] ProfileServer.Models.UpdateUserProfileRequest update)
        {
            var response = _profileServerService.UpdateUserProfiles(update).Result;
            return response;
        }

        [HttpDelete("deleteProfile/{profileId}")]
        public bool deleteUser(String profileId)
        {
            var response = _profileServerService.DeleteProfile(profileId).Result;
            return response;
        }

        [HttpGet("getUser/{email}")]
        public UserManagement getUser(String email)
        {
            var response = _profileServerService.GetUser(email).Result;
            return response;
        }
    }
}
