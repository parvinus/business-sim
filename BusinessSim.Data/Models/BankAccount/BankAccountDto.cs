using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSim.Data.Models.BankAccount
{
    public class BankAccountDto : CreateBankAccountDto
    {
        public Guid Id { get; set; }
    }
}
