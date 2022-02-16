using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem.OrderStates
{
    class OnGoingState : OrderState
    {
        public override void AddSeatReservation(MovieTicket movieTicket, List<MovieTicket> tickets)
        {
            tickets.Add(movieTicket);
        }
    }
}
