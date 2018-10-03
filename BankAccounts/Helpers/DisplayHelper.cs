namespace BankAccounts.Helpers
{
    public class DisplayHelper : IDisplayHelper
    {
        private readonly IConsoleHelper _consoleHelper;

        public DisplayHelper(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public void Display<T>(T entity)
        {
            _consoleHelper.WriteLine($"Displaying {typeof(T).Name}...");
            foreach(var property in typeof(T).GetProperties())
            {
                _consoleHelper.WriteLine($"{property.Name}:");
                _consoleHelper.WriteLine(property.GetValue(entity).ToString());
            }
        }
    }

    public interface IDisplayHelper
    {
        void Display<T>(T entity);
    }
}
