using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public abstract class ExportStrategy
    {
        public abstract void Export(Order order);
    }
}
