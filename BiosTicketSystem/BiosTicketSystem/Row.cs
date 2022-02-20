using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    class Row : ComponentComposite
    {
        public int rowNr;

        public Row(int rowNr)
        {
            this.rowNr = rowNr;
        }

        public override string ToString()
        {
            return "Row " + rowNr;
        }
    }
}
