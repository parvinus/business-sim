using System.Net;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.QueryableExtensions;
using BusinessSim.Data.Contexts;
using BusinessSim.Data.Enumerations;
using BusinessSim.Data.Models.BankAccount;
using BusinessSim.Data.Models.Response;
using Microsoft.Extensions.Configuration;

namespace BusinessSim.Services.BankAccount
{
    public class BankAccountService(IConfiguration configuration, IMapper mapper) : IBankAccountService
    {
        private readonly BusinessSimDbContext _context = new(configuration);
        
        public List<BankAccountDto> GetByParentId(Guid parentId, AccountType accountType)
        {
            var bankAccountList = _context.BankAccounts
                .UseAsDataSource(mapper.ConfigurationProvider)
                .For<BankAccountDto>()
                .Where(ba => ba.Type == accountType && ba.ParentId == parentId)
                .ProjectTo<BankAccountDto>(mapper.ConfigurationProvider)
                .ToList();
            
            

            return bankAccountList;
        }

        public BankAccountDto? GetById(Guid id)
        {
            var bankAccount = _context.BankAccounts
                .UseAsDataSource(mapper.ConfigurationProvider)
                .For<BankAccountDto>()
                .FirstOrDefault(ba => ba.Id == id);

            return bankAccount;
        }
        
        public BankAccountDto UpdateBalance(Guid id, decimal newBalance)
        {
            var bankAccount = _context.BankAccounts.FirstOrDefault(ba => ba.Id == id);

            if (bankAccount == null)
            {
                throw new Exception("Bank account not found");
            }

            bankAccount.Balance = newBalance;
            
            _context.BankAccounts.Update(bankAccount);
            _context.SaveChanges();

            return mapper.Map<BankAccountDto>(bankAccount);
        }

        public BankAccountDto Create(CreateBankAccountDto bankAccountDto)
        {
            var bankAccount = mapper.Map<Data.Entities.BankAccount>(bankAccountDto);
            _context.BankAccounts.Add(bankAccount);
            _context.SaveChanges();
            
            return mapper.Map<BankAccountDto>(bankAccount);
        }

        public BankAccountDto Update(BankAccountDto bankAccountDto)
        {
            var bankAccount = mapper.Map<Data.Entities.BankAccount>(bankAccountDto);
            
            _context.BankAccounts.Update(bankAccount);
            _context.SaveChanges();

            return mapper.Map<BankAccountDto>(bankAccount);
        }

        public bool Delete(Guid id)
        {
            var bankAccount = _context.BankAccounts
                .FirstOrDefault(ba => ba.Id == id);

            if (bankAccount == null)
            {
                return false;
            }

            _context.BankAccounts.Remove(bankAccount);
            return _context.SaveChanges() > 0;
        }
    }
}
