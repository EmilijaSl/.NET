using Microsoft.EntityFrameworkCore;
using pamoka11JWT.Models;

namespace pamoka11JWT.Database
{
    public class DbRepository : IDbRepository
    {
        //injectiname
        private readonly JwtDbContext _context;

        public DbRepository(JwtDbContext context)
        {
            _context = context;
        }

        public void Add(Accaunt accaunt)
        {
            _context.Add(accaunt);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Accaunt> GetAccauntAsync(string username)
        {
            return await _context.Accaunts.FirstOrDefaultAsync(a => a.Username == username);
        }
    
    }
}
