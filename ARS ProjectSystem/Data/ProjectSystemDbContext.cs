namespace ARS_ProjectSystem.Data
{
    using ARS_ProjectSystem.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class ProjectSystemDbContext : IdentityDbContext<User>
    {
        public ProjectSystemDbContext(DbContextOptions<ProjectSystemDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Programm> Programms { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Invoice>()
               .HasOne(c => c.Customer)
               .WithMany(c => c.Invoices)
               .HasForeignKey(c => c.CustomerRegistrationNumber)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Project>()
               .HasOne(c => c.Customer)
               .WithMany(c => c.Projects)
               .HasForeignKey(c => c.CustomerRegistrationNumber)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
