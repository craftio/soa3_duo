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

        public Room(int roomNr)
        {
            this.roomNr = roomNr;
        }

        public override string ToString()
        {
            return "Room " + roomNr;
        }
    }
}
