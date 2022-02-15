using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class RegularOrder : IOrder
    {
        private int orderNr;
        private List<MovieTicket> tickets;
        private DateTime day = DateTime.Now;

        public RegularOrder(int orderNr, bool isStudentOrder, DateTime? day = null)
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
                        price += 3;
                    }

                    sum += price;
                }

                i++;
            }

            //Discount
            if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
            {
                if (tickets.Count() >= 6)
                {
                    sum = (sum / 100) * 90;
                }
            }

            return sum;
        }

        public bool IsFree()
        {
            if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Tuesday || day.DayOfWeek == DayOfWeek.Wednesday || day.DayOfWeek == DayOfWeek.Thursday)
                return true;
            return false;
        }

        public void Export(ExportState exportState)
        {
            exportState.Export();
        }
    }
}
