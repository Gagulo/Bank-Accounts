using BankAccounts.Helpers;
using BankAccounts.Models;
using BankAccounts.Repositories;
using BankAccounts.Services;
using System;
using System.Windows.Forms;

namespace BankAccounts.Commands
{
    public class GetDataFromExcelTemplateCommand : IGetDataFromExcelTemplateCommand
    {
        private readonly IExcelService _excelService;
        private readonly IAccountsRepository _accountsRepository;
        private readonly IBankTransfersRepository _transfersRepository;
        private readonly IBankSitesRepository _bankSitesRepository;
        private readonly IConsoleHelper _consoleHelper; 

        public GetDataFromExcelTemplateCommand(IExcelService excelService, 
            IAccountsRepository accountsRepository, 
            IBankTransfersRepository bankTransfersRepository, 
            IBankSitesRepository bankSitesRepository,
            IConsoleHelper consoleHelper)
        {
            _excelService = excelService;
            _accountsRepository = accountsRepository;
            _transfersRepository = bankTransfersRepository;
            _bankSitesRepository = bankSitesRepository;
            _consoleHelper = consoleHelper;
        }

        public void Execute()
        {
            _consoleHelper.WriteLine("Getting data from excel template...");
            _consoleHelper.WriteLine("1) Account");
            _consoleHelper.WriteLine("2) Bank Transfer");
            _consoleHelper.WriteLine("3) Bank Site");
            var option = _consoleHelper.ReadKey();
            string path = "";
            switch (option)
            {
                case ConsoleKey.D1:
                    path = GetFilePath();
                    ImportAccounts(path);
                    break;
                case ConsoleKey.D2:
                    path = GetFilePath();
                    ImportTransfers(path);
                    break;
                case ConsoleKey.D3:
                    path = GetFilePath();
                    ImportBankSites(path);
                    break;
                default:
                    _consoleHelper.WriteLine("Wrong input, try again");
                    this.Execute();
                    break;
            }
        }

        private void ImportAccounts(string path)
        {
            var itemsList = _excelService.GetItemsFromTemplate<Account>(path);
            foreach(var item in itemsList)
            {
                _accountsRepository.Add(item);
            }
        }

        private void ImportTransfers(string path)
        {
            var itemsList = _excelService.GetItemsFromTemplate<BankTransfer>(path);
            foreach (var item in itemsList)
            {
                _transfersRepository.Add(item);
            }
        }

        private void ImportBankSites(string path)
        {
            var itemsList = _excelService.GetItemsFromTemplate<BankSite>(path);
            foreach (var item in itemsList)
            {
                _bankSitesRepository.Add(item);
            }
        }

        private string GetFilePath()
        {
            string fileName = "";
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Template file";
            fd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            fd.DefaultExt = "xlsx";
            fd.AddExtension = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fileName = fd.FileName;
            }
            return fileName;
        }
    }

    public interface IGetDataFromExcelTemplateCommand : ICommand
    { }
}
