using BusinessSim.Data.Enumerations;
using BusinessSim.Data.Models.BankAccount;
using BusinessSim.Data.Models.Response;

namespace BusinessSim.Services.BankAccount
{
    public interface IBankAccountService
    {
        List<BankAccountDto> GetByParentId(Guid parentId, AccountType accountType);
        BankAccountDto? GetById(Guid id);

        BankAccountDto UpdateBalance(Guid id, decimal newBalance);
        BankAccountDto Create(CreateBankAccountDto bankAccountDto);
        BankAccountDto Update(BankAccountDto bankAccountDto);
        bool Delete(Guid id);
    }
}
