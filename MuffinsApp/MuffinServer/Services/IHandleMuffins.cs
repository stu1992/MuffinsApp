using MuffinServer.Models;

namespace MuffinServer.Services
{
    public interface IHandleMuffins
    {
        Task<IEnumerable<Muffin>> ListMuffins();
        Task<bool> UpdateOrderedMuffins(Muffin[] muffins);
    }
}
