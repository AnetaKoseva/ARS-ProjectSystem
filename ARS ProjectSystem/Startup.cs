namespace ARS_ProjectSystem
{
    using ARS_ProjectSystem.Areas.Identity.Pages.Account;
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Controllers.Sms;
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Infrastructure;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Services.Contracts;
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Services.Employees;
    using ARS_ProjectSystem.Services.Invoices;
    using ARS_ProjectSystem.Services.Programms;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Proposals;
    using ARS_ProjectSystem.Services.Statistics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            =>Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<ProjectSystemDbContext>(options =>options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services
                .AddDatabaseDeveloperPageExceptionFilter();

            services.Configure<ReCAPTCHASettings>(Configuration.GetSection("GooglereCAPTCHA"));

            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("SendGrid"));
            services.Configure<SMSoptions>(Configuration.GetSection("Twilio"));

            services.AddTransient<GoogleRecaptchaService>();
            
                services
                .AddDefaultIdentity<User>(options => 
                {
                    options.User.RequireUniqueEmail = true;
                    //options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Lockout.DefaultLockoutTimeSpan=System.TimeSpan.FromMinutes(2);
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ProjectSystemDbContext>();
            
            services
                .AddAutoMapper(typeof(Startup));

            services.AddMemoryCache();
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                options.SchemaName = "dbo";
                options.TableName = "CacheRecords";
            });

            services
                .AddControllersWithViews(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                 });

            services
                .AddTransient<ICustomerService, CustomerService>();

            services
                .AddTransient<IStatisticsService, StatisticsService>();

            services
                .AddTransient<IProjectService, ProjectService>();

            services
                .AddTransient<IProposalService, ProposalService>();

            services
                .AddTransient<IEmployeeService, EmployeeService>();

            services
                .AddTransient<IProgrammService, ProgrammService>();

            services
                .AddTransient<IInvoiceService, InvoiceService>();

            services
                .AddTransient<IContractService, ContractService>();

            services
                .AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultAreaRoute();
                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
                    endpoints.MapControllerRoute(
                        name:"default",
                        pattern:"{controller=Home}/{action=Index}/{id?}"
                        );
                });
            
        }
    }
}
