using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    class Seat : ComponentComposite
    {
        public int seatNr;

        public Seat(int seatNr)
        {
            this.seatNr = seatNr;
        }

        public override string ToString()
        {
            return "Seat " + seatNr;
        }
    }
}
