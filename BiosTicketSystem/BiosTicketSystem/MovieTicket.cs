using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class MovieTicket
    {
        private int rowNr;
        private int seatNr;
        private bool isPremium = false;
        private MovieScreening movieScreening;

        public MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening movieScreening)
        {
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium = isPremium;
            this.movieScreening = movieScreening;
        }

        public bool IsPremiumTicket()
        {
            return isPremium;
        }

        public double GetPrice()
        {
            return movieScreening.GetPricePerSeat();
        }

        public override string ToString()
        {
            return movieScreening.ToString() + " - row " + rowNr + ", seat " + seatNr +
                (isPremium ? " (Premium)" : "");
        }
    }
}
