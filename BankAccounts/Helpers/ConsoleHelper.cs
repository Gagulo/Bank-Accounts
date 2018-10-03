using System;

namespace BankAccounts.Helpers
{
    public class ConsoleHelper : IConsoleHelper
    {
        public ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IConsoleHelper
    {
        void WriteLine(string message);
        ConsoleKey ReadKey();
        string ReadLine();
    }
}
