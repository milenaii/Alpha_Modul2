using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveller.Core.Contracts;
using Moq;
using Traveller.Core;
using Traveller.Commands.Creating;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTest
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();

            // Act
            var createTicketCommmand = new CreateTicketCommand(databaseMock.Object, factoryMock.Object);

            // Assert
            Assert.IsNotNull(createTicketCommmand); 

        }
        [TestMethod]
        public void ThrowsArgumentNullException_WhenFactoryIsNull()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(databaseMock.Object, null));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenDatabaseIsNull()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(null, factoryMock.Object));
        }

    }
}
