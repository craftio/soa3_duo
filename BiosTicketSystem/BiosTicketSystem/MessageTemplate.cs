using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public abstract class MessageTemplate
    {
        protected MessageTemplate() //final =/ sealed in C#?
        {
            Intro();
            Content();
            CopyRight();
            End();
        }

        public abstract void Intro();

        public void Content() { }

        public void CopyRight()
        {
            Console.WriteLine("Copyright");
        }

        public void End()
        {
            Console.WriteLine("END");
        }
    }
}
