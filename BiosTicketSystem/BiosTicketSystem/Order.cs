using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    class Order
    {
        private int orderNr;
        private bool isStudentOrder = false;
        private List<MovieTicket> tickets;
        private string day;

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            tickets = new List<MovieTicket>();
        }

        public int GetOrderNr()
        {
            return orderNr;
        }

        public void AddSeatReservation(MovieTicket movieTicket)
        {
            tickets.Add(movieTicket);
        }

        public double CalculatePrice()
        {
            double price = 0;
            double sum = 0;
            int i = 1;

            String day = "mon";

            foreach (MovieTicket ticket in tickets)
            {
                price = ticket.GetPrice();

                if (!(IsFree() && i % 2 == 0))
                {
                    if (ticket.IsPremiumTicket())
                    {
                        if (isStudentOrder)
                            price = price + 2;
                        else
                            price = price + 3;
                    }

                    sum += price;
                }

                i++;
            }

            //Discount
            if (day == "sat" || day == "sun")
            {
                if (!isStudentOrder && tickets.Count() >= 6)
                {
                    sum = (sum / 100) * 90;
                }
            }

            return sum;
        }

        public bool IsFree()
        {
            if (isStudentOrder)
            {
                return true;
            }
            else
            {
                if (day == "mon" || day == "tue" || day == "wed" || day == "thu")
                {
                    return true;
                }
            }

            return false;
        }

        public void Export(TicketExportFormat ticketExportFormat)
        {
            if (ticketExportFormat == TicketExportFormat.PLAINTEXT)
            {
                //Creating a filewriter object
            }
            else if (ticketExportFormat == TicketExportFormat.JSON)
            {
                //Creating a JSONObject object
            }
        }
    }
}
