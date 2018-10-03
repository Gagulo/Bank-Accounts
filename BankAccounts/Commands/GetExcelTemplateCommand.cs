using BankAccounts.Helpers;
using BankAccounts.Models;
using BankAccounts.Services;
using System;
using System.Windows.Forms;

namespace BankAccounts.Commands
{
    public class GetExcelTemplateCommand : IGetExcelTemplateCommand
    {
        private readonly IExcelService _excelService;
        private readonly IConsoleHelper _consoleHelper;

        public GetExcelTemplateCommand(IExcelService excelService,
            IConsoleHelper consoleHelper)
        {
            _excelService = excelService;
            _consoleHelper = consoleHelper;
        }

        public void Execute()
        {
            _consoleHelper.WriteLine("Getting excel template for data import...");
            _consoleHelper.WriteLine("1) Account");
            _consoleHelper.WriteLine("2) Bank Transfer");
            _consoleHelper.WriteLine("3) Bank Site");
            var option = _consoleHelper.ReadKey();
            string path = "";
            switch (option)
            {
                case ConsoleKey.D1:
                    path = GetSaveFilePath();
                    _excelService.CreateTemplateFile<Account>(path);
                    break;
                case ConsoleKey.D2:
                    path = GetSaveFilePath();
                    _excelService.CreateTemplateFile<BankTransfer>(path);
                    break;
                case ConsoleKey.D3:
                    path = GetSaveFilePath();
                    _excelService.CreateTemplateFile<BankSite>(path);
                    break;
                default:
                    _consoleHelper.WriteLine("Wrong input, try again");
                    this.Execute();
                    break;
            }
        }

        private string GetSaveFilePath()
        {
            string fileName = "";
            SaveFileDialog fd = new SaveFileDialog();
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

    public interface IGetExcelTemplateCommand : ICommand
    {
    }
}
