using _0_Framework.Application;
using AccontManagement.Application.Account;
using AccountManagement.Domian.AccountAgg;
using AccountMangemenr.Infrastructure;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Bootstraper
{
    public class ConfigureBootsrtap
    {
        public static void Config(IServiceCollection service,string connectionstring )
        {
            service.AddTransient<IRepository<Account>, Repository<Account>>();
            service.AddTransient<IAccountApplicationcs, AccountApplication>();
            



            service.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
