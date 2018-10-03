using BankAccounts.Helpers;
using BankAccounts.Models;
using BankAccounts.Repositories;

namespace BankAccounts.Factories
{
    public class TransfersFactory : ITransfersFactory
    {
        private readonly IBankTransfersRepository _transfersRepository;
        private readonly IInputHelper _inputHelper;
        private readonly IConsoleHelper _consoleHelper;

        public TransfersFactory(IBankTransfersRepository transfersRepository, IInputHelper inputHelper, 
            IConsoleHelper consoleHelper)
        {
            _transfersRepository = transfersRepository;
            _inputHelper = inputHelper;
            _consoleHelper = consoleHelper;
        }

        public BankTransfer Create()
        {
            _consoleHelper.WriteLine("Creating bank transfer...");
            _consoleHelper.WriteLine("SourceAccountNumber:");
            var sourceAccountNumber = _consoleHelper.ReadLine();
            _consoleHelper.WriteLine("TargetAccountNumber:");
            var targetAccountNumber = _consoleHelper.ReadLine();
            _consoleHelper.WriteLine("Title:");
            var title = _consoleHelper.ReadLine();
            _consoleHelper.WriteLine("Description:");
            var description = _consoleHelper.ReadLine();

            var value = _inputHelper.GetDecimalFromConsole("Value:");
            var timeCreated = _inputHelper.GetDateTimeFromConsole("TimeCreated:");


            var transfer = new BankTransfer
            {
                SourceAccountNumber = sourceAccountNumber,
                TargetAccountNumber = targetAccountNumber,
                Value = value,
                Title = title,
                Description = description,
                TimeCreated = timeCreated
            };

            _transfersRepository.Add(transfer);

            return transfer;
        }
    }

    public interface ITransfersFactory
    {
        BankTransfer Create();
    }
}
