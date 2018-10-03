using BankAccounts.Helpers;
using BankAccounts.Models;
using BankAccounts.Repositories;

namespace BankAccounts.Factories
{
    public class BankSitesFactory : IBankSitesFactory
    {
        private readonly IBankSitesRepository _bankSitesRepository;
        private readonly IInputHelper _inputHelper;
        private readonly IConsoleHelper _consoleHelper;

        public BankSitesFactory(IBankSitesRepository bankSitesRepository, IInputHelper inputHelper,
            IConsoleHelper consoleHelper)
        {
            _bankSitesRepository = bankSitesRepository;
            _inputHelper = inputHelper;
            _consoleHelper = consoleHelper;
        }

        public BankSite Create()
        {
            _consoleHelper.WriteLine("Creating bank site...");
            _consoleHelper.WriteLine("Name:");
            var name = _consoleHelper.ReadLine();
            _consoleHelper.WriteLine("City:");
            var city = _consoleHelper.ReadLine();
            _consoleHelper.WriteLine("Street:");
            var street = _consoleHelper.ReadLine();
            
            var number = _inputHelper.GetIntFromConsole("Street number:");
            _consoleHelper.WriteLine("Postal code:");
            var postalCode = _consoleHelper.ReadLine();


            var bankSite = new BankSite
            {
                Name = name,
                AddressCity = city,
                AddressStreet = street,
                AddressStreetNumber = number,
                AddressPostalCode = postalCode
            };

            _bankSitesRepository.Add(bankSite);

            return bankSite;

        }
    }

    public interface IBankSitesFactory
    {
        BankSite Create();
    }
}
