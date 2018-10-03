using BankAccounts.Factories;
using BankAccounts.Helpers;
using BankAccounts.Models;
using BankAccounts.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankAccounts.Tests.Factories
{
    [TestClass]
    public class BankSitesFactoryTests
    {
        private Mock<IBankSitesRepository> _bankSitesRepositoryMock;
        private Mock<IInputHelper> _inputHelperMock;
        private Mock<IConsoleHelper> _consoleHelperMock;
        private BankSitesFactory _bankSitesFactory;

        [TestInitialize]
        public void Initialize()
        {
            _bankSitesRepositoryMock = new Mock<IBankSitesRepository>();
            _inputHelperMock = new Mock<IInputHelper>();
            _consoleHelperMock = new Mock<IConsoleHelper>();
            _bankSitesFactory = new BankSitesFactory(_bankSitesRepositoryMock.Object, _inputHelperMock.Object, _consoleHelperMock.Object);
        }

        [TestMethod]
        public void Create_ShouldCreateABankSiteBasedOnDataReturnedFromConsole()
        {
            // Arrange
            var testName = "TestSite";
            var testCity = "TestCity";
            var testStreet = "TestStreet";
            var testStreetNumber = 12;
            var testPostalCode = "TestCode";
            _consoleHelperMock.SetupSequence(x => x.ReadLine())
                .Returns(testName)
                .Returns(testCity)
                .Returns(testStreet)
                .Returns(testPostalCode);
            _inputHelperMock.Setup(x => x.GetIntFromConsole(It.IsAny<string>())).Returns(testStreetNumber);

            // Act
            var result = _bankSitesFactory.Create();

            // Assert
            Assert.AreEqual(testName, result.Name);
            Assert.AreEqual(testCity, result.AddressCity);
            Assert.AreEqual(testStreet, result.AddressStreet);
            Assert.AreEqual(testStreetNumber, result.AddressStreetNumber);
            Assert.AreEqual(testPostalCode, result.AddressPostalCode);
        }

        [TestMethod]
        public void Create_ShouldCallAddOnBankSitesRepository()
        {
            // Arrange
            var testName = "TestSite";
            var testCity = "TestCity";
            var testStreet = "TestStreet";
            var testStreetNumber = 12;
            var testPostalCode = "TestCode";
            _consoleHelperMock.SetupSequence(x => x.ReadLine())
                .Returns(testName)
                .Returns(testCity)
                .Returns(testStreet)
                .Returns(testPostalCode);
            _inputHelperMock.Setup(x => x.GetIntFromConsole(It.IsAny<string>())).Returns(testStreetNumber);

            // Act
            var result = _bankSitesFactory.Create();

            // Assert
            _bankSitesRepositoryMock.Verify(x =>
            x.Add(
                It.Is<BankSite>(
                    y => y.Name == testName &&
                    y.AddressCity == testCity &&
                    y.AddressStreet == testStreet &&
                    y.AddressStreetNumber == testStreetNumber &&
                    y.AddressPostalCode == testPostalCode)), Times.Once);
        }
    }
}
