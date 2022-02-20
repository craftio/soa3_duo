using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    class Facility : ComponentComposite
    {
        public string name;
        public string address;

        public Facility(string name, string address, int? limit = null)
        {
            this.name = name;
            this.address = address;
            this.limit = limit;
        }

        public override string ToString()
        {
            return name + " in " + address;
        }
    }
}
