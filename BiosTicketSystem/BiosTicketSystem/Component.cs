using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public abstract class Component
    {
        public abstract int? limit { get; set; }

        protected Component() //final =/ sealed in C#?
        {
            //limit = null;
        }

        public abstract void PrintContent();
    }
}
