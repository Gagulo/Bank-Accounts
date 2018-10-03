using BankAccounts.Attributes;

namespace BankAccounts.Models
{
    public class BankSite
    {
        public int Id { get; set; }
        [ExcelMetadata("Nazwa", 1)]
        public string Name { get; set; }
        [ExcelMetadata("Ulica", 2)]
        public string AddressStreet { get; set; }
        [ExcelMetadata("Numer budynku", 3)]
        public int AddressStreetNumber { get; set; }
        [ExcelMetadata("Miasto", 4)]
        public string AddressCity { get; set; }
        [ExcelMetadata("Kod pocztowy", 5)]
        public string AddressPostalCode { get; set; }
    }
}
