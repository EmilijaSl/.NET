using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Weather
    {
        public int Id { get; set; }
        public int Temperature { get; set; }    
        public string Country { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
    }
}
