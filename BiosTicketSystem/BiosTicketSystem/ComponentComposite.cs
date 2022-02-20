using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class ComponentComposite : Component
    {
        private List<Component> parts;
        private int? limit = null;

        public ComponentComposite() //Zitplaats -> rij -> zaal -> vestiging
        {
            parts = new List<Component>();
        }

        public void AddComponent(Component comp)
        {
           if (limit == null || limit > GetSize())
                parts.Add(comp);
            else
                Console.WriteLine("Not enough space!");
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
            foreach(Component component in parts)
            {
                Console.WriteLine(parts.ToString());
                component.PrintContent();
            }
        }
    }
}
