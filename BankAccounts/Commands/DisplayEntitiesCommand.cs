using BankAccounts.Helpers;
using BankAccounts.Repositories;
using System;

namespace BankAccounts.Commands
{
    public class DisplayEntitiesCommand : IDisplayEntitiesCommand
    {
        private readonly IDisplayHelper _displayHelper;
        private readonly IAccountsRepository _accountsRepository;
        private readonly IBankTransfersRepository _bankTransfersRepository;
        private readonly IBankSitesRepository _bankSitesRepository;
        private readonly IConsoleHelper _consoleHelper;

        public DisplayEntitiesCommand(IDisplayHelper displayHelper, 
            IAccountsRepository accountsRepository, 
            IBankTransfersRepository bankTransfersRepository, 
            IBankSitesRepository bankSitesRepository,
            IConsoleHelper consoleHelper)
        {
            _displayHelper = displayHelper;
            _accountsRepository = accountsRepository;
            _bankTransfersRepository = bankTransfersRepository;
            _bankSitesRepository = bankSitesRepository;
            _consoleHelper = consoleHelper;
        }

        public void Execute()
        {
            _consoleHelper.WriteLine("Displaying entities...");
            _consoleHelper.WriteLine("1) Accounts");
            _consoleHelper.WriteLine("2) Bank Transfers");
            _consoleHelper.WriteLine("3) Bank Sites");
            var option = _consoleHelper.ReadKey();

            switch (option)
            {
                case ConsoleKey.D1:
                    DisplayAccounts();
                    break;
                case ConsoleKey.D2:
                    DisplayTransfers();
                    break;
                case ConsoleKey.D3:
                    DisplayBankSites();
                    break;
                default:
                    _consoleHelper.WriteLine("Wrong input, try again");
                    this.Execute();
                    break;
            }
        }

        private void DisplayAccounts()
        {
            var accounts = _accountsRepository.GetAll();
            _consoleHelper.WriteLine("Displaying all accounts...");
            foreach(var account in accounts)
            {
                _displayHelper.Display(account);
            }
        }

        private void DisplayTransfers()
        {
            var transfers = _bankTransfersRepository.GetAll();
            _consoleHelper.WriteLine("Displaying all transfers...");
            foreach (var transfer in transfers)
            {
                _displayHelper.Display(transfer);
            }
        }

        private void DisplayBankSites()
        {
            var bankSites = _bankSitesRepository.GetAll();
            _consoleHelper.WriteLine("Displaying all bank sites...");
            foreach (var bankSite in bankSites)
            {
                _displayHelper.Display(bankSite);
            }
        }
    }

    public interface IDisplayEntitiesCommand : ICommand
    {
    }
}
