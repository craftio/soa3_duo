using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class JsonStrategy : ExportStrategy
    {
        public override void Export(Order order)
        {
            Console.WriteLine("JSON EXPORT");
        }
    }
}
