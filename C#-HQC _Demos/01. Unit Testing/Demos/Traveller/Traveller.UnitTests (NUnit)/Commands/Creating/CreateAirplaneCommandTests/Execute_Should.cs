using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Factories;

namespace Traveller.UnitTests.Commands.Creating.CreateAirplaneCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        private const string SuccessMessageTemplate = 
            "Vehicle with ID {0} was created.";

        [Test]
        public void ReturnSuccessMessage_WhenParametersAreCorrect()
        {
            // Arrange
            List<string> parameters = new List<string>();
            parameters.Add("250");
            parameters.Add("2.0");
            parameters.Add("true");

            string result = string.Format(SuccessMessageTemplate, 0);
            CreateAirplaneCommand command = 
                new CreateAirplaneCommand(TravellerFactory.Instance, Engine.Instance);

            // Act
            string actualResult = command.Execute(parameters);

            // Assert
            Assert.AreEqual(result, actualResult);
        }

        [TestCase("invalid capacity", "2.0", "true")]
        [TestCase("250", "invalid price", "true")]
        [TestCase("250", "2.0", "invalid boolean")]
        public void ThrowException_WhenParametersAreNotCorrect(string passangerCapacity, 
            string pricePerKilometer, string hasFreeFood)
        {
            // Arrange
            List<string> parameters = new List<string>()
            { passangerCapacity, pricePerKilometer, hasFreeFood };
            
            CreateAirplaneCommand command = 
                new CreateAirplaneCommand(TravellerFactory.Instance, Engine.Instance);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }
    }
}