using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem.OrderStates
{
    public abstract class OrderState
    {
        public abstract void AddSeatReservation(MovieTicket movieTicket, List<MovieTicket> tickets);
    }
}
