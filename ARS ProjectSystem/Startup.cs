namespace ARS_ProjectSystem
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Infrastructure;
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Services.Employees;
    using ARS_ProjectSystem.Services.Platform;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Proposals;
    using ARS_ProjectSystem.Services.Statistics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
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
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<ProjectSystemDbContext>(options =>options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services
                .AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddDefaultIdentity<User>(options => 
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ProjectSystemDbContext>();
            
            services
                .AddAutoMapper(typeof(Startup));
            services.AddMemoryCache();
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
                .AddTransient<IPlatformService, PlatformService>();
            services
                .AddTransient<IEmployeeService, EmployeeService>();

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
                });
            
        }
    }
}
