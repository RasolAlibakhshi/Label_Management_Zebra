
using _0_Framework.Application;
using _0_FrameWork.Application;
using Domain;
using HambaftManagement.Bootstraper;
using Infrastructure;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
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


            var connectionstring = builder.Configuration.GetConnectionString("EFCoreSQLServer");

            builder.Services.AddHttpContextAccessor();

            ConfigureBootsrtap.Config(builder.Services, connectionstring);
            builder.Services.AddTransient<IFileUploder, FileUploader>();
            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            AccountManagement.Bootstraper.ConfigureBootsrtap.Config(builder.Services, connectionstring);


            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Admin/Menu");
                    o.LogoutPath = new PathString("/Admin/Index");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });
            builder.Services.AddAuthorization(option =>
                {
                    // option.AddPolicy("AdminArea", builder => builder.RequireRole(new List<string> { Roles.Adminstration }));
                    option.AddPolicy("Accounts", builder=>builder.RequireRole(new List<string> { Roles.Adminstration ,Roles.Informatique}));
                    option.AddPolicy("Hall",builder=>builder.RequireRole(new List<string>{Roles.Adminstration,Roles.PersonInCharge}));
                    option.AddPolicy("Machine",builder=>builder.RequireRole(new List<string>{Roles.Adminstration,Roles.PersonInCharge}));
                    option.AddPolicy("Label", builder => builder.RequireRole(new List<string> { Roles.Adminstration, Roles.PersonInCharge,Roles.Design,Roles.ShiftManager }));
                    option.AddPolicy("LabelType", builder => builder.RequireRole(new List<string> { Roles.Adminstration, Roles.Informatique }));
            
                }
                );
            builder.Services.AddRazorPages().AddRazorPagesOptions(option =>
            {
                // option.Conventions.AuthorizeAreaFolder("Admin", "/", "AdminArea");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Accounts/Manage", "Accounts");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Accounts/Account/AccountManagement", "Accounts");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Accounts/Account/AddAccount", "Accounts");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Accounts/Account/EditAccount", "Accounts");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Accounts/Role/EditeRole", "Accounts");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Accounts/Role/RoleManagement", "Accounts");

                option.Conventions.AuthorizeAreaFolder("Admin", "/Hall/HallManegment", "Hall");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Hall/EditeHall", "Hall");

                option.Conventions.AuthorizeAreaFolder("Admin", "/Machine/MachineManegment", "Machine");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Machine/EditeMachineManegment", "Machine");

                option.Conventions.AuthorizeAreaFolder("Admin", "/Label/InterwovenManagement", "Label");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Label/EditeInterwoven", "Label");
                option.Conventions.AuthorizeAreaFolder("Admin", "/Label/EditeInterwoven", "AddLabel");


                option.Conventions.AuthorizeAreaFolder("Admin", "/LabelType/AddLabelType", "LabelType");
                option.Conventions.AuthorizeAreaFolder("Admin", "/LabelType/EditeLabelType", "LabelType");
                option.Conventions.AuthorizeAreaFolder("Admin", "/LabelType/LabelTypeManagement", "LabelType");
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
