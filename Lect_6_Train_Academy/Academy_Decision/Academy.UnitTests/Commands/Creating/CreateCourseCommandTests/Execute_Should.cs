using Academy.Commands.Creating;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Academy.UnitTests.Commands.Creating.CreateCourseCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateCourseAndAddItToSeason_WhenParametersAreCorrect()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstSeasonMock = new Mock<ISeason>();
            var secondSeasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();
            List<ISeason> seasons = new List<ISeason>()
            { firstSeasonMock.Object, secondSeasonMock.Object };
            List<ICourse> courses = new List<ICourse>();

            string courseName = "JavaScriptOOP";
            string lecturesPerWeek = "2";
            string startingDate = "2017-01-24";

            databaseMock.SetupGet(m => m.Seasons).Returns(seasons);
            factoryMock
                .Setup(m => m.CreateCourse(courseName, lecturesPerWeek, startingDate))
                .Returns(courseMock.Object);

            secondSeasonMock.SetupGet(m => m.Courses).Returns(courses);

            List<string> parameters = new List<string>()
            {
                "1",
                courseName,
                lecturesPerWeek,
                startingDate
            };

            CreateCourseCommand command = new CreateCourseCommand(factoryMock.Object, databaseMock.Object);

            // Act
            command.Execute(parameters);

            // Assert
            Assert.AreEqual(1, secondSeasonMock.Object.Courses.Count);
            Assert.AreSame(courseMock.Object, secondSeasonMock.Object.Courses.Single());
        }

        [TestMethod]
        public void ReturnText_WhenParametersAreCorrect()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstSeasonMock = new Mock<ISeason>();
            var secondSeasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();
            var firstCourseMock = new Mock<ICourse>();
            List<ISeason> seasons = new List<ISeason>()
            { firstSeasonMock.Object, secondSeasonMock.Object };
            List<ICourse> courses = new List<ICourse>();
            courses.Add(firstCourseMock.Object);

            string seasonId = "1";
            string courseName = "JavaScriptOOP";
            string lecturesPerWeek = "2";
            string startingDate = "2017-01-24";

            string expectedResult = $"Course with ID 1 was created in Season {seasonId}.";

            databaseMock.SetupGet(m => m.Seasons).Returns(seasons);
            factoryMock
                .Setup(m => m.CreateCourse(courseName, lecturesPerWeek, startingDate))
                .Returns(courseMock.Object);

            secondSeasonMock.SetupGet(m => m.Courses).Returns(courses);

            List<string> parameters = new List<string>()
            {
                seasonId,
                courseName,
                lecturesPerWeek,
                startingDate
            };

            CreateCourseCommand command = new CreateCourseCommand(factoryMock.Object, databaseMock.Object);

            // Act
            var result = command.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
