using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OlympicGames.Core.Contracts;
using System.Collections.Generic;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Core.Commands;

namespace OlympicGames.Framework.UnitTests.Core.Commands.CreateBoxerCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenArgumentsAreValid()
        {
            // Arrange

            var committeMock = new Mock<IOlympicCommittee>();
            var factoryMock = new Mock<IOlympicsFactory>();

            // Act
            var createBoxerCommmand = new CreateBoxerCommand(committeMock.Object, factoryMock.Object);

            // Assert
            Assert.IsNotNull(createBoxerCommmand);
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenFactoryIsNull()
        {
            // Arrange
            var committeeMock = new Mock<IOlympicCommittee>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateBoxerCommand(committeeMock.Object, null));
           
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenDatabaseIsNull()
        {
            // Arrange
            var factoryMock = new Mock<IOlympicsFactory>();

            // Act & Assert

            Assert.ThrowsException<ArgumentNullException>(() => new CreateBoxerCommand(factoryMock.Object, null));

        }
    }
}
