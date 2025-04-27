using _0_Framework.Application;
using AccontManagement.Application.Account;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
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
            service.AddTransient<IRepository<Role>, Repository<Role>>();

            service.AddTransient<IAccountApplicationcs, AccountApplication>();
            service.AddTransient<IRoleApplication, RoleApplication>();

            service.AddTransient<IAuthHelper, AuthHelper>();
            



            service.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
