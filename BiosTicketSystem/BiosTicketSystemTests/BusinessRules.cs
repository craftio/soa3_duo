using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiosTicketSystem;
using System.Collections.Generic;
using Moq;

namespace BiosTicketSystemTests
{
    [TestClass]
    public class BusinessRules
    {
        //Elk 2e ticket is gratis voor studenten (elke dag van de week) of als het een voorstelling betreft op een doordeweekse dag (ma/di/wo/do) voor iedereen.
        [TestMethod]
        public void EachSecondTicketIsFreeForStudents()
        {
            // Arrange
            Order order = new Order(999, true, new DateTime(DateTime.Today.Year, 2, 11)); //Is student order
            Order nonStudentOrder = new Order(999, false, new DateTime(DateTime.Today.Year, 2, 11)); //Is NOT student order

            Movie JamesBond = new Movie("James Bond");
            Movie ChickenLittle = new Movie("Chicken Little");

            MovieScreening movieScreening1 = new MovieScreening(DateTime.Now, 5, JamesBond);
            MovieScreening movieScreening2 = new MovieScreening(DateTime.Now, 10, ChickenLittle);

            MovieTicket ticket1 = new MovieTicket(3, 3, false, movieScreening1);
            MovieTicket ticket2 = new MovieTicket(8, 7, false, movieScreening2);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            nonStudentOrder.AddSeatReservation(ticket1);
            nonStudentOrder.AddSeatReservation(ticket2);

            // Act
            var result = order.CalculatePrice();
            var result2 = nonStudentOrder.CalculatePrice();

            //Assert
            Assert.AreEqual(5, result);
            Assert.AreEqual(15, result2);
            Assert.AreNotEqual(result2, result);
        }

        //In het weekend betaal je als niet-student de volle prijs, tenzij de bestelling uit 6 kaartjes of meer bestaat, dan krijg je 10% groepskorting.
        [TestMethod]
        public void NonStudentsGet10ProcentDiscountWhenMoreThan6TicketsInTheWeekend()
        {
            // Arrange
            Order order = new Order(999, false, new DateTime(DateTime.Today.Year, 2, 12)); //Saturday -> weekend
            Order order6Tickets = new Order(999, false, new DateTime(DateTime.Today.Year, 2, 12)); //Saturday -> weekend
            Order nonWeekendOrder = new Order(999, false, new DateTime(DateTime.Today.Year, 2, 11)); //Friday

            Movie JamesBond = new Movie("James Bond");
            Movie ChickenLittle = new Movie("Chicken Little");

            MovieScreening movieScreening1 = new MovieScreening(DateTime.Now, 5, JamesBond);
            MovieScreening movieScreening2 = new MovieScreening(DateTime.Now, 10, ChickenLittle);

            MovieTicket ticket1 = new MovieTicket(3, 3, false, movieScreening1);
            MovieTicket ticket2 = new MovieTicket(8, 7, false, movieScreening2);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order6Tickets.AddSeatReservation(ticket1);
            order6Tickets.AddSeatReservation(ticket1);
            order6Tickets.AddSeatReservation(ticket1);
            order6Tickets.AddSeatReservation(ticket2);
            order6Tickets.AddSeatReservation(ticket2);
            order6Tickets.AddSeatReservation(ticket2);

            nonWeekendOrder.AddSeatReservation(ticket1);
            nonWeekendOrder.AddSeatReservation(ticket1);
            nonWeekendOrder.AddSeatReservation(ticket1);
            nonWeekendOrder.AddSeatReservation(ticket2);
            nonWeekendOrder.AddSeatReservation(ticket2);
            nonWeekendOrder.AddSeatReservation(ticket2);

            // Act
            var result = order.CalculatePrice();
            var result2 = order6Tickets.CalculatePrice();
            var result3 = nonWeekendOrder.CalculatePrice();

            //Assert
            Assert.AreEqual(15, result);
            Assert.AreEqual(40.5f, result2); //10% off
            Assert.AreEqual(45f, result3);
        }

        //Een premium ticket is voor studenten 2,- duurder dan de standaardprijs per stoel van de voorstelling, voor niet-studenten 3,-.
        //Deze worden in de kortingen verrekend (dus bij een 2e ticket dat gratis is, ook geen extra kosten; bij 10% korting ook 10% van de extra kosten).
        [TestMethod]
        public void PremiumTicketIs2EuroMoreExpensiveForStudentsAnd3EuroForNonStudents()
        {
            // Arrange
            Order order = new Order(999, false, new DateTime(DateTime.Today.Year, 2, 11)); //Friday
            Order studentOrder = new Order(999, true, new DateTime(DateTime.Today.Year, 2, 11)); //Friday

            Movie JamesBond = new Movie("James Bond");
            Movie ChickenLittle = new Movie("Chicken Little");

            MovieScreening movieScreening1 = new MovieScreening(DateTime.Now, 5, JamesBond);
            MovieTicket ticket1 = new MovieTicket(3, 3, true, movieScreening1);

            order.AddSeatReservation(ticket1);
            studentOrder.AddSeatReservation(ticket1);

            // Act
            var result = order.CalculatePrice();
            var result2 = studentOrder.CalculatePrice();

            //Assert
            Assert.AreEqual(8, result);
            Assert.AreEqual(7, result2);
        }
    }
}
