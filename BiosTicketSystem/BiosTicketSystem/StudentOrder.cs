using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class StudentOrder : IOrder
    {
        private int orderNr;
        private List<MovieTicket> tickets;
        private DateTime day = DateTime.Now;

        public StudentOrder(int orderNr, bool isStudentOrder, DateTime? day = null)
        {
            this.orderNr = orderNr;

            if (day != null)
                this.day = (DateTime)day;

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

            foreach (MovieTicket ticket in tickets)
            {
                price = ticket.GetPrice();

                if (!(IsFree() && i % 2 == 0))
                {
                    if (ticket.IsPremiumTicket())
                    {
                        price += 2;
                    }

                    sum += price;
                }

                i++;
            }

            return sum;
        }

        public bool IsFree()
        {
            return true;
        }

        public void Export(ExportState exportState)
        {
            exportState.Export();
        }
    }
}
