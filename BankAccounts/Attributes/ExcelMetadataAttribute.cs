using System;

namespace BankAccounts.Attributes
{
    public class ExcelMetadataAttribute : Attribute
    {
        public int ColumnNumber { get; set; }
        public string Header { get; set; }

        public ExcelMetadataAttribute(string header, int columnNumber)
        {
            Header = header;
            ColumnNumber = columnNumber;
        }
    }
}
