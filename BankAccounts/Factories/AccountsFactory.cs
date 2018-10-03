using BankAccounts.Helpers;
using BankAccounts.Models;
using BankAccounts.Repositories;

namespace BankAccounts.Factories
{
    public class AccountsFactory : IAccountsFactory
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IInputHelper _inputHelper;
        private readonly IConsoleHelper _consoleHelper;

        public AccountsFactory(IAccountsRepository accountsRepository, IInputHelper inputHelper,
            IConsoleHelper consoleHelper)
        {
            _accountsRepository = accountsRepository;
            _inputHelper = inputHelper;
            _consoleHelper = consoleHelper;
        }

        public Account Create()
        {
            _consoleHelper.WriteLine("Creating account...");
            _consoleHelper.WriteLine("Name:");
            var name = _consoleHelper.ReadLine();
            _consoleHelper.WriteLine("Number:");
            var number = _consoleHelper.ReadLine();
            var value = _inputHelper.GetDecimalFromConsole("Value:");

            var account = new Account
            {
                Name = name,
                Number = number,
                Value = value
            };

            _accountsRepository.Add(account);

            return account;

        }
    }

    public interface IAccountsFactory
    {
        Account Create();
    }
}
