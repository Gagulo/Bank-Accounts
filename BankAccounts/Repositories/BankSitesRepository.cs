using BankAccounts.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankAccounts.Repositories
{
    public class BankSitesRepository : IBankSitesRepository
    {
        private static int _maxId = 0;
        private static List<BankSite> _bankSites = new List<BankSite>();

        public int Add(BankSite bankSite)
        {
            bankSite.Id = ++_maxId;
            _bankSites.Add(bankSite);
            return _maxId;
        }

        public IEnumerable<BankSite> GetAll()
        {
            return _bankSites.ToList();
        }
    }

    public interface IBankSitesRepository
    {
        int Add(BankSite account);
        IEnumerable<BankSite> GetAll();
    }
}
