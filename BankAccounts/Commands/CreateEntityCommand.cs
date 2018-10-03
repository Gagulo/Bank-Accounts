using BankAccounts.Factories;
using BankAccounts.Helpers;
using System;

namespace BankAccounts.Commands
{
    public class CreateEntityCommand : ICreateEntityCommand
    {
        private readonly IAccountsFactory _accountsFactory;
        private readonly ITransfersFactory _transfersFactory;
        private readonly IBankSitesFactory _bankSitesFactory;
        private readonly IConsoleHelper _consoleHelper;

        public CreateEntityCommand(IAccountsFactory accountsFactory, ITransfersFactory transfersFactory, IBankSitesFactory bankSitesFactory, IConsoleHelper consoleHelper)
        {
            _accountsFactory = accountsFactory;
            _transfersFactory = transfersFactory;
            _bankSitesFactory = bankSitesFactory;
            _consoleHelper = consoleHelper;
        }

        public void Execute()
        {
            _consoleHelper.WriteLine("Creating entity...");
            _consoleHelper.WriteLine("1) Account");
            _consoleHelper.WriteLine("2) Bank Transfer");
            _consoleHelper.WriteLine("3) Bank Site");
            var option = _consoleHelper.ReadKey();

            switch (option)
            {
                case ConsoleKey.D1:
                    _accountsFactory.Create();
                    break;
                case ConsoleKey.D2:
                    _transfersFactory.Create();
                    break;
                case ConsoleKey.D3:
                    _bankSitesFactory.Create();
                    break;
                default:
                    _consoleHelper.WriteLine("Wrong input, try again");
                    this.Execute();
                    break;
            }
        }
    }

    public interface ICreateEntityCommand : ICommand
    {
    }
}
