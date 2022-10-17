using AutoFixture.Kernel;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class WeatherSpecimentBuilder :ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is Type type && type == typeof(Weather))
            {
                return new Weather
                {
                    Country = "Lithuania",
                    Id = 1,
                    Language = "lt",
                    Region = "Kaunas",
                    Temperature = 16
                };
            }
            return new NoSpecimen();
        }
    }
}
