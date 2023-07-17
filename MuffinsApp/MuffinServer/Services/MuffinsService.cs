using MuffinServer.Models;
using MuffinServer.Repositories;

namespace MuffinServer.Services
{
    public class MuffinsService : IHandleMuffins
    {
        public async Task<IEnumerable<Muffin>> ListMuffins()
        {
            MuffinRepository repo = new MuffinRepository();
            var response = await repo.GetMuffins();
            return response;
        }

        public async Task<bool> UpdateOrderedMuffins(Muffin[] muffins)
        {
            MuffinRepository repo = new MuffinRepository();
            
            var sortedMuffins = muffins.ToList();
            sortedMuffins.Sort();
            return await repo.UpdateMuffins(sortedMuffins);
        }
    }
}
