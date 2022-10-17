using Microsoft.EntityFrameworkCore;
using pamoka11JWT.Models;

namespace pamoka11JWT.Database
{
    public class JwtDbContext :DbContext
    {
        public DbSet<Accaunt> Accaunts { get; set; }

        public JwtDbContext(DbContextOptions options) : base(options)
        { 
        
        }
    }
}
