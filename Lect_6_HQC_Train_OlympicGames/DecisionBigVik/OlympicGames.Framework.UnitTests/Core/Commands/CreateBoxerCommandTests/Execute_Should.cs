using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OlympicGames.Framework.UnitTests.Core.Commands.CreateBoxerCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateBoxerAndAddItToDatabase_WhenParametersAreCorrect()
        {
            // Arrange
            List<string> commandLine = new List<string>()
            {
                "first name",
                "last name",
                "country",
                "category",
                "1",
                "1"
            };

            List<IOlympian> olympians = new List<IOlympian>();

            var databaseMock = new Mock<IOlympicCommittee>();
            var factoryMock = new Mock<IOlympicsFactory>();
            var boxerMock = new Mock<IOlympian>();

            databaseMock.SetupGet(m => m.Olympians).Returns(olympians);

            factoryMock.Setup(m =>
            m.CreateBoxer(It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>())).Returns(boxerMock.Object);
            
            var command = new CreateBoxerCommand(databaseMock.Object, factoryMock.Object);

            // Act
            command.Execute(commandLine);

            // Assert
            Assert.AreEqual(1, databaseMock.Object.Olympians.Count);
            Assert.AreEqual(boxerMock.Object, databaseMock.Object.Olympians.Single());
        }
    }
}
