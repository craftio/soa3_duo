using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem.OrderStates
{
    class ConfirmedState : OrderState
    {
        public override void AddSeatReservation(MovieTicket movieTicket, List<MovieTicket> tickets)
        {
            Console.WriteLine("Cannot add new seat because the order has been confirmed already.");
        }
    }
}
