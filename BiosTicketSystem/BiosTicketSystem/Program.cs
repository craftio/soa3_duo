using System;

namespace BiosTicketSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Order order = new Order(999, true);

            Movie JamesBond = new Movie("James Bond");
            Movie ChickenLittle = new Movie("Chicken Little");

            MovieScreening movieScreening1 = new MovieScreening(DateTime.Now, 5, JamesBond);
            MovieScreening movieScreening2 = new MovieScreening(DateTime.Now, 10, ChickenLittle);
            MovieScreening movieScreening3 = new MovieScreening(DateTime.Now, 10, ChickenLittle);
            MovieScreening movieScreening4 = new MovieScreening(DateTime.Now, 5, JamesBond);

            MovieTicket ticket1 = new MovieTicket(3, 3, false, movieScreening1);
            MovieTicket ticket2 = new MovieTicket(8, 7, false, movieScreening2);
            MovieTicket ticket3 = new MovieTicket(4, 8, false, movieScreening3);
            MovieTicket ticket4 = new MovieTicket(6, 1, false, movieScreening4);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);

            Console.WriteLine("Total price: " + order.CalculatePrice());
            order.Export(new JsonState());
            order.Export(new PlainTextState());
        }
    }
}
