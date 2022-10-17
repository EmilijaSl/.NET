using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Fundamentals_Scott_Allen
{
    public class Model
    {
        public Model(string name)
        {
            Name = name; //propeerty Name = incoming name value name.
        }

        public string Name { get; set; }
    }
}
