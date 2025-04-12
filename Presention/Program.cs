
using _0_Framework.Application;
using Domain;
using HambaftManagement.Bootstraper;
using Infrastructure;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using ServiceHost;

namespace Presention
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var connectionstring = builder.Configuration.GetConnectionString("EFCoreSQLServer");


            ConfigureBootsrtap.Config(builder.Services, connectionstring);
            builder.Services.AddTransient<IFileUploder, FileUploader>();
            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            AccountManagement.Bootstraper.ConfigureBootsrtap.Config(builder.Services, connectionstring);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.MapRazorPages();

            app.Run();
        }
    }
}
