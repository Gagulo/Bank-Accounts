using BankAccounts.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankAccounts.Repositories
{
    public class BankTransfersRepository : IBankTransfersRepository
    {
        private static int _maxId = 0;
        private static List<BankTransfer> _bankTransfers = new List<BankTransfer>();

        public int Add(BankTransfer bankTransfer)
        {
            bankTransfer.Id = ++_maxId;
            _bankTransfers.Add(bankTransfer);
            return _maxId;
        }

        public IEnumerable<BankTransfer> GetAll()
        {
            return _bankTransfers.ToList();
        }
    }

    public interface IBankTransfersRepository
    {
        int Add(BankTransfer account);
        IEnumerable<BankTransfer> GetAll();
    }
}
