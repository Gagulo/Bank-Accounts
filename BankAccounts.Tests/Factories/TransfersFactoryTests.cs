using BankAccounts.Factories;
using BankAccounts.Helpers;
using BankAccounts.Models;
using BankAccounts.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BankAccounts.Tests.Factories
{
    [TestClass]
    public class TransfersFactoryTests
    {
        private Mock<IBankTransfersRepository> _bankTransfersRepositoryMock;
        private Mock<IInputHelper> _inputHelperMock;
        private Mock<IConsoleHelper> _consoleHelperMock;
        private TransfersFactory _transfersFactory;

        [TestInitialize]
        public void Initialize()
        {
            _bankTransfersRepositoryMock = new Mock<IBankTransfersRepository>();
            _inputHelperMock = new Mock<IInputHelper>();
            _consoleHelperMock = new Mock<IConsoleHelper>();
            _transfersFactory = new TransfersFactory(_bankTransfersRepositoryMock.Object, _inputHelperMock.Object, _consoleHelperMock.Object);
        }

        [TestMethod]
        public void Create_ShouldCreateATransferBasedOnDataReturnedFromConsole()
        {
            // Arrange
            var testSourceAccountNumber = "TestSourceAccountNumber";
            var testDestinationAccountNumber = "TestDestinationAccountNumber";
            var testTitle = "TestTitle";
            var testDescription = "TestDescription";
            var testValue = (decimal)25.67;
            var testTimeCreated = DateTime.Now;
            _consoleHelperMock.SetupSequence(x => x.ReadLine())
                .Returns(testSourceAccountNumber)
                .Returns(testDestinationAccountNumber)
                .Returns(testTitle)
                .Returns(testDescription);
            _inputHelperMock.Setup(x => x.GetDecimalFromConsole(It.IsAny<string>())).Returns(testValue);
            _inputHelperMock.Setup(x => x.GetDateTimeFromConsole(It.IsAny<string>())).Returns(testTimeCreated);

            // Act
            var result = _transfersFactory.Create();

            // Assert
            Assert.AreEqual(testSourceAccountNumber, result.SourceAccountNumber);
            Assert.AreEqual(testDestinationAccountNumber, result.TargetAccountNumber);
            Assert.AreEqual(testTitle, result.Title);
            Assert.AreEqual(testDescription, result.Description);
            Assert.AreEqual(testValue, result.Value);
            Assert.AreEqual(testTimeCreated, result.TimeCreated);
        }

        [TestMethod]
        public void Create_ShouldCallAddOnTransfersRepository()
        {
            // Arrange
            var testSourceAccountNumber = "TestSourceAccountNumber";
            var testDestinationAccountNumber = "TestDestinationAccountNumber";
            var testTitle = "TestTitle";
            var testDescription = "TestDescription";
            var testValue = (decimal)25.67;
            var testTimeCreated = DateTime.Now;
            _consoleHelperMock.SetupSequence(x => x.ReadLine())
                .Returns(testSourceAccountNumber)
                .Returns(testDestinationAccountNumber)
                .Returns(testTitle)
                .Returns(testDescription);
            _inputHelperMock.Setup(x => x.GetDecimalFromConsole(It.IsAny<string>())).Returns(testValue);
            _inputHelperMock.Setup(x => x.GetDateTimeFromConsole(It.IsAny<string>())).Returns(testTimeCreated);

            // Act
            var result = _transfersFactory.Create();

            // Assert
            _bankTransfersRepositoryMock.Verify(x =>
            x.Add(
                It.Is<BankTransfer>(
                    y => y.SourceAccountNumber == testSourceAccountNumber &&
                    y.TargetAccountNumber == testDestinationAccountNumber &&
                    y.Title == testTitle &&
                    y.Description == testDescription &&
                    y.Value == testValue &&
                    y.TimeCreated == testTimeCreated)), Times.Once);
        }
    }
}
