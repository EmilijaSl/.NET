using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberService
{
    public class RandomNumberGenerator:IRandomNumberGenerator
    {
        public int RandomNumber { get; }
        public RandomNumberGenerator()
        { 
        Random rnd = new Random();
            RandomNumber = rnd.Next(1, 100);
        }
    }
}
