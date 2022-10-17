using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherBackend;

namespace Infrastucture.HttpLayer
{
    public interface IWeatherHttpRepository
    {
        Task<Weather> GetWeatherDataAsync(string city);
    }
}
