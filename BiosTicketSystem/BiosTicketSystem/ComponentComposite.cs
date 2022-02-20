using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class ComponentComposite : Component //Zitplaats -> rij -> zaal -> vestiging
    {
        private List<Component> parts = new List<Component>();

        public override int? limit { get; set; }

        public void AddComponent(Component comp)
        {
            if (limit == null || (int)limit > GetSize())
            {
                parts.Add(comp);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enough space in {0} for an additional {1}!", ToString(), comp.GetType().ToString().Replace(System.Reflection.Assembly.GetEntryAssembly().GetName().Name + ".", ""));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public Component GetComponent(int i)
        {
            return parts[i];
        }

        public int GetSize()
        {
            return parts.Count();
        }

        public override void PrintContent()
        {
            if(this is Facility)
                Console.WriteLine(ToString() + ": ");

            foreach(Component component in parts)
            {
                Console.WriteLine(component.ToString());
                component.PrintContent();
            }
        }
    }
}
