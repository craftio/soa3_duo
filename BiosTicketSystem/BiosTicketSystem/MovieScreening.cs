using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class MovieScreening
    {
        private DateTime localDateTime;
        private double pricePerSeat;
        private Movie movie;

        public MovieScreening(DateTime localDateTime, double pricePerSeat, Movie movie)
        {
            this.localDateTime = localDateTime;
            this.pricePerSeat = pricePerSeat;
            this.movie = movie;

            movie.AddScreening(this);
        }

        public double GetPricePerSeat()
        {
            return pricePerSeat;
        }

        public override string ToString()
        {
            return movie.ToString() + " - " + localDateTime;
        }
    }
}
