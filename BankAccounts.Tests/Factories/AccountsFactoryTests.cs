using BankAccounts.Factories;
using BankAccounts.Helpers;
using BankAccounts.Models;
using BankAccounts.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankAccounts.Tests.Factories
{
    [TestClass]
    public class AccountsFactoryTests
    {
        private Mock<IAccountsRepository> _accountsRepositoryMock;
        private Mock<IInputHelper> _inputHelperMock;
        private Mock<IConsoleHelper> _consoleHelperMock;
        private AccountsFactory _accountsFactory;

        [TestInitialize]
        public void Initialize()
        {
            _accountsRepositoryMock = new Mock<IAccountsRepository>();
            _inputHelperMock = new Mock<IInputHelper>();
            _consoleHelperMock = new Mock<IConsoleHelper>();
            _accountsFactory = new AccountsFactory(_accountsRepositoryMock.Object, _inputHelperMock.Object, _consoleHelperMock.Object);
        }

        [TestMethod]
        public void Create_ShouldCreateAnAccountBasedOnDataReturnedFromConsole()
        {
            // Arrange
            var testName = "TestAccount";
            var testNumber = "12345abc";
            var testValue = (decimal)25.67;
            _consoleHelperMock.SetupSequence(x => x.ReadLine())
                .Returns(testName)
                .Returns(testNumber);
            _inputHelperMock.Setup(x => x.GetDecimalFromConsole(It.IsAny<string>())).Returns(testValue);

            // Act
            var result = _accountsFactory.Create();

            // Assert
            Assert.AreEqual(testName, result.Name);
            Assert.AreEqual(testNumber, result.Number);
            Assert.AreEqual(testValue, result.Value);
        }

        [TestMethod]
        public void Create_ShouldCallAddOnAccountsRepository()
        {
            // Arrange
            var testName = "TestAccount";
            var testNumber = "12345abc";
            var testValue = (decimal)25.67;
            _consoleHelperMock.SetupSequence(x => x.ReadLine())
                .Returns(testName)
                .Returns(testNumber);
            _inputHelperMock.Setup(x => x.GetDecimalFromConsole(It.IsAny<string>())).Returns(testValue);

            // Act
            var result = _accountsFactory.Create();

            // Assert
            _accountsRepositoryMock.Verify(x =>
            x.Add(
                It.Is<Account>(
                    y => y.Name == testName &&
                    y.Number == testNumber &&
                    y.Value == testValue)), Times.Once);
        }
    }
}
