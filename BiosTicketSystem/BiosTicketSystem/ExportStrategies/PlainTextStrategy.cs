using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class PlainTextStrategy : ExportStrategy
    {
        public override void Export(Order order)
        {
            Console.WriteLine("PLAIN TEXT EXPORT");
        }
    }
}
