using BusinessSim.Data.Enumerations;

namespace BusinessSim.Data.Models.BankAccount
{
    public class CreateBankAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public Guid ParentId { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }
    }
}
