using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    class Room : ComponentComposite
    {
        public int roomNr;

        public Room(int roomNr, int? limit = null)
        {
            this.roomNr = roomNr;
            this.limit = limit;
        }

        public override string ToString()
        {
            return "Room " + roomNr;
        }
    }
}
