using MuffinServer.Models;
using MuffinServer.Repositories;

namespace MuffinServer.Services
{
    public class MuffinsService : IHandleMuffins
    {
        /*
        public async Task<IEnumerable<Muffin>> ListMuffins()
        {
            MuffinRepository repo = new MuffinRepository();
            var response = await repo.GetMuffins();
            return response;
        }
        */

        public async Task<bool> AddUser(NewUser user)
        {
            MuffinRepository repo = new MuffinRepository();
            return await repo.AddUser(user);
        }

        public async Task<bool> AddProfile(Profile profile)
        {
            MuffinRepository repo = new MuffinRepository();
            return await repo.AddProfile(profile);
        }
    }
}
