using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDomain
{
    public class ContactDetail
    {
        public int Id { get; set; } 
        public ContactType Type { get; set; }
        public string ContactValue { get; set; }
    }
}
