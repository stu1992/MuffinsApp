using MuffinServer.Models;

namespace MuffinServer.Repositories
{
    public interface IMuffins
    {
        public Task<IEnumerable<Muffin>> GetMuffins();
        public Task<bool> UpdateMuffins(IEnumerable<Muffin> muffins);
    }
}
