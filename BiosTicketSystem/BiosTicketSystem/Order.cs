﻿using System;
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

            this.day = DateTime.Today.DayOfWeek;  // moeten dit nog aanpassen maar klopt ook niet in word doc die op brightspace staat

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
            if (day == "Saturday" || day == "Sunday")
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
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday")
                {
                    return true;
                }
            }

            return false;
        }

        public void Export(TicketExportFormat ticketExportFormat)
        {
            List<data> _data = new List<data>();
            _data.Add(new data()
            {
                OrderNr = this.orderNr,
                OrderType = (isStudentOrder ? " (Student)" : "(Regular)"),
                Tickets = this.tickets,
                Day = this.day
            });

            if (ticketExportFormat == TicketExportFormat.PLAINTEXT)
            {
                string json = JsonConvert.SerializeObject(_data.ToArray());
                System.IO.File.WriteAllText(@"D:\path.txt", json);
            }
            else if (ticketExportFormat == TicketExportFormat.JSON)
            {
                string json = JsonSerializer.Serialize(_data);
                File.WriteAllText(@"D:\path.json", json);
            }
        }
    }
}