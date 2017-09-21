using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core.Contracts;
using Traveller.Commands.Creating;
using System.Collections.Generic;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTest
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ShouldCreateAddTicketToDatabaseAndReturnSuccessMessage_WhenParametersAreValid()
        {
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();

        }
        [TestMethod]
        public void ShouldThrowArgumentOutOfRangeException_WhenParametersListIsNotFull()
        {
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();

            var parameters = new List<string>()
            {
                "just name"
            };

            var createTicketCommand = new CreateTicketCommand(databaseMock.Object, factoryMock.Object);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => createTicketCommand.Execute(parameters));
        }
    }
}
