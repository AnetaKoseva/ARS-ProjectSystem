namespace ARS_ProjectSystem.Data
{
    using ARS_ProjectSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Employee>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Employee>()
                .HasOne(c => c.Department)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
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
            //builder
            //   .Entity<Project>()
            //   .HasOne(c => c.Programm)
            //   .WithMany(c => c.Projects)
            //   .HasForeignKey(c => c.ProgrammId)
            //   .OnDelete(DeleteBehavior.Restrict);
            
            //builder
            //    .Entity<Proposal>()
            //    .HasOne<Customer>()
            //    .WithOne()
            //    .HasForeignKey<Proposal>(p => p.CustomerId)
            //    .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(builder);
        }
    }
}
