using ProfileServer.Models;

namespace ProfileServer.Services
{
    public interface IHandleProfiles
    {
        Task<bool> AddProfile(Profile profile);
        Task<bool> AddUser(CreateNewUserRequest user);
        Task<bool> UpdateProfile(UpdateProfileRequest profile);
        Task<bool> UpdateUserProfiles(UpdateUserProfileRequest payload);
        Task<bool> DeleteProfile (String profileId);
        Task<UserManagement> GetUser(String email);
    }
}
