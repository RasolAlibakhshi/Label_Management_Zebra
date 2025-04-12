using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Application.Execution.Hall;
using Application.Execution.Label;
using Application.Execution.LabelType;
using Application.Execution.Machine;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;


namespace HambaftManagement.Bootstraper
{
    public static class ConfigureBootsrtap
    {
        public static void Config(IServiceCollection service,string connectionstring)
        {
            service.AddTransient<IRepository<Domain.Hall>,Repository<Domain.Hall>>();
            service.AddTransient<IRepository<Domain.Machine>, Repository<Domain.Machine>>();
            service.AddTransient<IRepository<Domain.label>, Repository<Domain.label>>();
            service.AddTransient<IRepository<Domain.LabelType>, Repository<Domain.LabelType>>();


            service.AddTransient<IHallApplication,HallApplication>();
            service.AddTransient<IMachineApplication,MachineApplication>();
            service.AddTransient<ILabelApplication,LabelApplication>();
            service.AddTransient<ILabelTypeApplication,LabelTypeApplication>();


            
            service.AddDbContext<Infrastructure.Context>(x => x.UseSqlServer(connectionstring));

        }
    }
}
