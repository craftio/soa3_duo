using System;

namespace BiosTicketSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Composite pattern gebruiken voor zetels & locatie etc. Geweldig voor het maken van een hierarchie
            CompositePatternCreateSeatsAndLocations();

            Order order = new Order(999, true);

            Movie JamesBond = new Movie("James Bond");
            Movie ChickenLittle = new Movie("Chicken Little");

            MovieScreening movieScreening1 = new MovieScreening(DateTime.Now, 5, JamesBond);
            MovieScreening movieScreening2 = new MovieScreening(DateTime.Now, 10, ChickenLittle);
            MovieScreening movieScreening3 = new MovieScreening(DateTime.Now, 10, ChickenLittle);
            MovieScreening movieScreening4 = new MovieScreening(DateTime.Now, 5, JamesBond);

            MovieTicket ticket1 = new MovieTicket(3, 3, false, movieScreening1); //TODO: instant of a simple number add the posibility to add true rows and seats types to ticket
            MovieTicket ticket2 = new MovieTicket(8, 7, false, movieScreening2);
            MovieTicket ticket3 = new MovieTicket(4, 8, false, movieScreening3);
            MovieTicket ticket4 = new MovieTicket(6, 1, false, movieScreening4);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);

            Console.WriteLine("Total price: " + order.CalculatePrice());
            order.Export(new JsonStrategy());
            order.Export(new PlainTextStrategy());
        }

        public static void CompositePatternCreateSeatsAndLocations()
        {
            Facility facilityA = new Facility("Bios Zevenbergen", "Zevenbergen", 3);
            Facility facilityB = new Facility("Bios Breda", "Breda", 1); //Not enough space
            Facility facilityC = new Facility("Bios Noordhoek", "Noordhoek", 3);

            Room room1 = new Room(1);
            Room room2 = new Room(2);
            Room room3 = new Room(3);
            Room room4 = new Room(4);
            Room room5 = new Room(5);
            Room room6 = new Room(6);
            Room room7 = new Room(7);
            Room room8 = new Room(8);

            facilityA.AddComponent(room1);
            facilityA.AddComponent(room2);
            facilityA.AddComponent(room3);

            facilityB.AddComponent(room4);
            facilityB.AddComponent(room5);

            facilityC.AddComponent(room6);
            facilityC.AddComponent(room7);
            facilityC.AddComponent(room8);

            Row row1 = new Row(1);
            Row row2 = new Row(2);
            Row row3 = new Row(3);
            Row row4 = new Row(4);

            room1.AddComponent(row1);
            room1.AddComponent(row2);
            room1.AddComponent(row3);
            room1.AddComponent(row4);

            Seat seat1 = new Seat(1);
            Seat seat2 = new Seat(2);
            Seat seat3 = new Seat(3);
            Seat seat4 = new Seat(4);
            Seat seat5 = new Seat(5);
            Seat seat6 = new Seat(6);
            Seat seat7 = new Seat(7);
            Seat seat8 = new Seat(8);
            Seat seat9 = new Seat(9);

            row1.AddComponent(seat1);
            row1.AddComponent(seat2);
            row1.AddComponent(seat3);

            row2.AddComponent(seat4);
            row2.AddComponent(seat5);
            row2.AddComponent(seat6);

            row3.AddComponent(seat7);
            row3.AddComponent(seat8);
            row3.AddComponent(seat9);

            facilityA.PrintContent();
            Console.WriteLine();
            facilityB.PrintContent();
            Console.WriteLine();
            facilityC.PrintContent();
            Console.WriteLine();
        }
    }
}
