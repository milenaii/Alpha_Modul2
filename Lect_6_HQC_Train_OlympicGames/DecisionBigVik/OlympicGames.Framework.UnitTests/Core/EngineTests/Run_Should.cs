using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using System;

namespace OlympicGames.Framework.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Run_Should
    {
        [TestMethod]
        public void CallWriteMethodWithExceptionMessage_WhenExceptionIsThrown()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var processorMock = new Mock<ICommandProcessor>();
            var commandMock = new Mock<ICommand>();
            string exceptionMessage = "test";
            string messageToWrite = string.Format("ERROR: {0}", exceptionMessage);

            readerMock.SetupSequence(m => m.Read())
                .Returns("some command")
                .Returns("end");

            parserMock
                .Setup(m => m.ParseCommand(It.IsAny<string>()))
                .Returns(commandMock.Object);

            processorMock
                .Setup(m => m.ProcessSingleCommand(commandMock.Object, It.IsAny<string>()))
                .Throws(new Exception(exceptionMessage));

            var engine = new Engine(readerMock.Object,
                writerMock.Object, parserMock.Object, processorMock.Object);

            // Act
            engine.Run();
            
            // Assert
            writerMock.Verify(m => m.Write(messageToWrite), Times.Once());
        }
    }
}
