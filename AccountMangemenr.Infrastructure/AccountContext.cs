using _0_Framework.Application;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domian.AccountAgg;
using AccountMangemenr.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AccountMangemenr.Infrastructure
{

    public class AccountContext:DbContext
    {
        IPasswordHasher _PasswordHasher { get; set; }
        public DbSet<Account> Accounts { set; get; }
        public DbSet<Role> Roles { set; get; }
        public AccountContext(DbContextOptions<AccountContext>options, IPasswordHasher passwordHasher) :base(options)
        {
            _PasswordHasher=passwordHasher;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccontMaping).Assembly);
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Account>().HasData(new Account("admin", "admin", @"10000.TTrlm8E5W6vyza2TATY3eQ==.QbkEGcEjjlGEIuCC/GUGlfyg+PjKAOEQtjFrCJxEr9M=", 5) { ID = 1,IsDeleted = false,CreaationDateTime = new DateTime(2025, 4, 27, 12, 0, 0) });

            modelBuilder.Entity<Role>().HasData(
                new Role("برنامه ریزی"){ID = 1},
                new Role("سرشیفت"){ID = 2},
                new Role("انفورماتیک"){ID = 3},
                new Role("سرپرست"){ID = 4},
                new Role("ادمین سیستم"){ID = 5}
                );
        }
    }


}
