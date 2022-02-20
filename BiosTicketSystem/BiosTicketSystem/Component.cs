using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public abstract class Component
    {
        protected Component() //final =/ sealed in C#?
        {
            PrintContent();
        }

        public abstract void PrintContent();
    }
}
