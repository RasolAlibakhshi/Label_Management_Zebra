using AccountManagement.Domian.AccountAgg;
using AccountMangemenr.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AccountMangemenr.Infrastructure
{

    public class AccountContext:DbContext
    {
        public DbSet<Account> Accounts { set; get; }
        public AccountContext(DbContextOptions<AccountContext>options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccontMaping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }


}
