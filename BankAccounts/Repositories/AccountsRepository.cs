using BankAccounts.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankAccounts.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private static int _maxId = 0;
        private static List<Account> _accounts = new List<Account>();

        public int Add(Account account)
        {
            account.Id = ++_maxId;
            _accounts.Add(account);
            return _maxId;
        }

        public IEnumerable<Account> GetAll()
        {
            return _accounts.ToList();
        }
    }

    public interface IAccountsRepository
    {
        int Add(Account account);
        IEnumerable<Account> GetAll();
    }
}
