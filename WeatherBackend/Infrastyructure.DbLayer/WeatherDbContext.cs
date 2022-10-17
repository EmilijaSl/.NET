using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastyructure.DbLayer
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<Weather> WeatherEntries { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        { 
        
        }
    }
}
