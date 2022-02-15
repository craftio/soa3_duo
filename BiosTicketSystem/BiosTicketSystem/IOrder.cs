using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public interface IOrder
    {
        int GetOrderNr();
        void AddSeatReservation(MovieTicket movieTicket);
        double CalculatePrice();
        bool IsFree();
        void Export(ExportState exportState);
    }
}
