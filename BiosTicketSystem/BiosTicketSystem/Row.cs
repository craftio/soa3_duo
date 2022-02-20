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

        public Row(int rowNr, int? limit = null)
        {
            this.rowNr = rowNr;
            this.limit = limit;
        }

        public override string ToString()
        {
            return "Row " + rowNr;
        }
    }
}
