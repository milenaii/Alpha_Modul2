using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using System;

namespace OlympicGames.Framework.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var processorMock = new Mock<ICommandProcessor>();

            // Act
            var engine = new Engine(readerMock.Object,
                writerMock.Object, parserMock.Object, processorMock.Object);

            // Assert
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void ThrowException_WhenReaderArgumentIsNull()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var processorMock = new Mock<ICommandProcessor>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => 
            new Engine(null,
                writerMock.Object, parserMock.Object, processorMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenWriterArgumentIsNull()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var parserMock = new Mock<ICommandParser>();
            var processorMock = new Mock<ICommandProcessor>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new Engine(readerMock.Object,
                null, parserMock.Object, processorMock.Object));
        }
    }
}