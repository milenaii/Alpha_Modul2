using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlympicGames.Core.Providers;
using Moq;
using OlympicGames.Core.Contracts;
using OlympicGames.Core;

namespace UnitTestProject1.Core.EngineTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var processorMock = new Mock<ICommandProcessor>();
            var commandMock = new Mock<ICommand>();


            readerMock.SetupSequence(m => m.Read())
                .Returns("some command")
                .Returns("end");

            parserMock.Setup(m => m.ParseCommand(It.IsAny<string>()))
            .Returns(commandMock.Object);

            processorMock.Setup(m => m.ProcessSingleCommand(commandMock.Object, It.IsAny<string>()))
                .Throws(new Exception("except message"));

            var engine = new Engine(readerMock.Object,
               writerMock.Object, parserMock.Object, processorMock.Object);

            // Act
            engine.Run();

            //Assert
            writerMock.Verify(m => m.Write("messageToWrite"),Times.Once());
        }
    }
}
