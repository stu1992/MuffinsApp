using MuffinServer.Models;

namespace MuffinServer.Services
{
    public interface IHandleMuffins
    {
        //Task<IEnumerable<Muffin>> ListMuffins();
        Task<bool> AddProfile(Profile profile);
        Task<bool> AddUser(NewUser user);
    }
}
