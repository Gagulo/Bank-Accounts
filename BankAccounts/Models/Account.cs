using BankAccounts.Attributes;

namespace BankAccounts.Models
{
    public class Account
    {
        public int Id { get; set; }
        [ExcelMetadata("Nazwa", 1)]
        public string Name { get; set; }
        [ExcelMetadata("Numer", 2)]
        public string Number { get; set; }
        [ExcelMetadata("Środki na koncie", 3)]
        public decimal Value { get; set; }
    }
}
