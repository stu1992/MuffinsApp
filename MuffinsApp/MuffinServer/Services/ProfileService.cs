using ProfileServer.Models;
using ProfileServer.Repositories;

namespace ProfileServer.Services
{
    public class MuffinsService : IHandleProfiles
    {

        public async Task<bool> AddUser(CreateNewUserRequest user)
        {
            if (user.profiles.Length > 0)
            {
                MuffinRepository repo = new MuffinRepository();
                return await repo.AddUser(user);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddProfile(Profile profile)
        {
            MuffinRepository repo = new MuffinRepository();
            return await repo.AddProfile(profile);
        }

        public async Task<bool> UpdateProfile(UpdateProfileRequest profile)
        {
            MuffinRepository repo = new MuffinRepository();
            return await repo.UpdateProfile(profile);
        }

        public async Task<bool> UpdateUserProfiles(UpdateUserProfileRequest payload)
        {
            if (payload.profiles.Length > 0)
            {
                MuffinRepository repo = new MuffinRepository();
                return await repo.UpdateUserProfiles(payload);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteProfile(string profileId)
        {
            MuffinRepository repo = new MuffinRepository();
            return await repo.DeleteProfile(profileId);
        }

        public async Task<UserManagement> GetUser(string email)
        {
            MuffinRepository repo = new MuffinRepository();
            return await repo.GetUser(email);
        }
    }
}
