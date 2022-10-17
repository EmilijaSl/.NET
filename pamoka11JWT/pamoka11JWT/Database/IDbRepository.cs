using pamoka11JWT.Models;

namespace pamoka11JWT.Database
{
    public interface IDbRepository
    {
        void Add(Accaunt accaunt);
        Task CommitAsync();
        Task<Accaunt> GetAccauntAsync(string username);
  

    }
}
