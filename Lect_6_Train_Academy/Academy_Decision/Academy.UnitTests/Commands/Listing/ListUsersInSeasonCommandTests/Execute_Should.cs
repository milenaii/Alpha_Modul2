using Academy.Commands.Listing;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.UnitTests.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnStringRepresentingUsers_WhenParametersAreCorrect()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var firstSeasonMock = new Mock<ISeason>();
            var secondSeasonMock = new Mock<ISeason>();
            List<ISeason> seasons = new List<ISeason>()
            {
                firstSeasonMock.Object,
                secondSeasonMock.Object
            };

            List<string> parameters = new List<string>()
            {
                "1"
            };

            string expectedResult = "listing users";

            databaseMock.SetupGet(m => m.Seasons).Returns(seasons);
            secondSeasonMock.Setup(m => m.ListUsers()).Returns(expectedResult);

            ListUsersInSeasonCommand command = new ListUsersInSeasonCommand(databaseMock.Object);

            // Act
            var result = command.Execute(parameters);

            // Assert
            secondSeasonMock.Verify(m => m.ListUsers(), Times.Once());
            Assert.AreEqual(expectedResult, result);
        }
    }
}