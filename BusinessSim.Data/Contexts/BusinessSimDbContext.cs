using BusinessSim.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessSim.Data.Contexts
{
    public class BusinessSimDbContext(IConfiguration configuration) : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessDepartment> BusinessDepartments { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BusinessSim"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
