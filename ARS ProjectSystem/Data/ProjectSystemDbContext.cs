namespace ARS_ProjectSystem.Data
{
    using ARS_ProjectSystem.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class ProjectSystemDbContext : IdentityDbContext
    {
        public ProjectSystemDbContext(DbContextOptions<ProjectSystemDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Programm> Programms { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProjectSystemUser> ProjectSystemUsers { get; set; }
        
    }
}
