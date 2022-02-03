using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BiosTicketSystemTests
{
    class BusinessRules
    {
        //Het maximaal aantal afspraken per week wordt niet overschreden bij het boeken van een afspraak.
        [Fact]
        public void EachSecondTicketIsFreeForStudents()
        {
            // Arrange
            //var loggerMock = new Mock<Movie>();

            // Act
            var result = true;

            //Assert
            Assert.Equals(result, true);
        }
    }
}
