using BankAccounts.Commands;
using BankAccounts.Helpers;
using System;
using Unity;

namespace BankAccounts
{
    class Program
    {
        private static readonly IConsoleHelper _consoleHelper = IoC.Container.Resolve<IConsoleHelper>();

        [STAThread]
        static void Main(string[] args)
        {
            do
            {
                DisplayMainMenu();
                ChooseMainMenuItem();
                _consoleHelper.WriteLine("Press escape to exit or any key to go again");
            } while (_consoleHelper.ReadKey() != ConsoleKey.Escape);
        }
        
        private static void DisplayMainMenu()
        {
            _consoleHelper.WriteLine("Main menu");
            _consoleHelper.WriteLine("1) Create entity");
            _consoleHelper.WriteLine("2) Display entities");
            _consoleHelper.WriteLine("3) Download excel template");
            _consoleHelper.WriteLine("4) Import data from excel template");
        }

        private static void ChooseMainMenuItem()
        {
            var option = _consoleHelper.ReadKey();
            switch (option)
            {
                case ConsoleKey.D1:
                    IoC.Container.Resolve<ICreateEntityCommand>().Execute();
                    break;
                case ConsoleKey.D2:
                    IoC.Container.Resolve<IDisplayEntitiesCommand>().Execute();
                    break;
                case ConsoleKey.D3:
                    IoC.Container.Resolve<IGetExcelTemplateCommand>().Execute();
                    break;
                case ConsoleKey.D4:
                    IoC.Container.Resolve<IGetDataFromExcelTemplateCommand>().Execute();
                    break;
                default:
                    _consoleHelper.WriteLine("Wrong input, please try again");
                    ChooseMainMenuItem();
                    break;
            }
        }
    }
}
