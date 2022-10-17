using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastyructure.DbLayer
{
    public class WeatherDbRepository : IWeatherDbRepository
    {
        private readonly WeatherDbContext _context;
        public WeatherDbRepository(WeatherDbContext context)
        {
            _context = context;
        }
        public async Task InsertAsync(Weather weatherEntry)
        { 
        _context.Add(weatherEntry);
        await _context.SaveChangesAsync();
        }
    }
}
