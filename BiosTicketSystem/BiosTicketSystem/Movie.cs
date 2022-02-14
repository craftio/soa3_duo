using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class Movie
    {
        private string title;
        private List<MovieScreening> screenings;

        public Movie(string title)
        {
            this.title = title;
            screenings = new List<MovieScreening>();
        }

        public void AddScreening(MovieScreening movieScreening)
        {
            screenings.Add(movieScreening);
        }

        public override string ToString()
        {
            return title;
        }
    }
}
