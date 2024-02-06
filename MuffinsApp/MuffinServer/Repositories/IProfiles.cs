using ProfileServer.Models;

namespace ProfileServer.Repositories
{
    public interface IMuffins
    {
        public Task<bool> AddProfile(Profile profile);
        public Task<bool> UpdateProfile(UpdateProfileRequest profile);
        public Task<bool> AddUser(CreateNewUserRequest user);
        public Task<bool> UpdateUserProfiles(UpdateUserProfileRequest payload);
        public Task<bool> DeleteProfile(String profileId);
        public Task<UserManagement> GetUser(String email);
    }
}
