using System;
using System.Globalization;

namespace BankAccounts.Helpers
{
    public class InputHelper : IInputHelper
    {
        private readonly IConsoleHelper _consoleHelper;

        public InputHelper(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public int GetIntFromConsole(string message)
        {
            _consoleHelper.WriteLine(message);
            var input = _consoleHelper.ReadLine();

            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                return GetIntFromConsole(message);
            }
        }

        public decimal GetDecimalFromConsole(string message)
        {
            _consoleHelper.WriteLine(message);
            var input = _consoleHelper.ReadLine();
            
            if (decimal.TryParse(input, out decimal result))
            {
                return result;
            }
            else
            {
                return GetDecimalFromConsole(message);
            }
        }

        public DateTime GetDateTimeFromConsole(string message)
        {
            _consoleHelper.WriteLine($"{message}(dd/MM/YYYY HH:mm:ss)");
            var input = _consoleHelper.ReadLine();

            if (DateTime.TryParseExact(input, "dd/MM/YYYY HH:mm:ss", null, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            else
            {
                return GetDateTimeFromConsole(message);
            }
        }
    }

    public interface IInputHelper
    {
        int GetIntFromConsole(string message);

        decimal GetDecimalFromConsole(string message);

        DateTime GetDateTimeFromConsole(string message);
    }
}
