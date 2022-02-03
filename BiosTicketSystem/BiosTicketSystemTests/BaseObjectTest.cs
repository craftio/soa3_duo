using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiosTicketSystem;
using System.Collections.Generic;

namespace BiosTicketSystemTests
{
    [TestClass]
    public class BaseObjectTest
    {
        private Order order;
        private List<Movie> movies;
        private List<MovieScreening> moviescreenings;
        private List<MovieTicket> movietickets;

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ArrangeOrder();


            // Act
            

            // Assert
            double price = order.CalculatePrice();
            Assert.AreEqual(price, 12.0, "Prijs klopt niet met de verwachting");
        }

        public void ArrangeOrder()
        {
            order = new Order(999, true);

            movies.Add(new Movie("James Bond"));        // movies[0]
            movies.Add(new Movie("Chicken Little"));    // movies[1]

            moviescreenings.Add(new MovieScreening(DateTime.Now, 5, movies.ElementAt(0)));
            moviescreenings.Add(new MovieScreening(DateTime.Now, 10, movies.ElementAt(1)));
            moviescreenings.Add(new MovieScreening(DateTime.Now, 10, movies.ElementAt(1)));
            moviescreenings.Add(new MovieScreening(DateTime.Now, 5, movies.ElementAt(0)));

            movietickets.Add(new MovieTicket(3, 3, false, moviescreenings.ElementAt(0)));
            movietickets.Add(new MovieTicket(8, 7, false, moviescreenings.ElementAt(1)));
            movietickets.Add(new MovieTicket(4, 8, false, moviescreenings.ElementAt(2)));
            movietickets.Add(new MovieTicket(6, 1, false, moviescreenings.ElementAt(3)));

            order.AddSeatReservation(movietickets.ElementAt(0));
            order.AddSeatReservation(movietickets.ElementAt(1));
            order.AddSeatReservation(movietickets.ElementAt(2));
            order.AddSeatReservation(movietickets.ElementAt(3));
        }
    }
}
