namespace ARS_ProjectSystem.Test.Data
{
    using ARS_ProjectSystem.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class ProjectSystem
    {
        public static IEnumerable<Project> TenProjects()
            => Enumerable.Range(0, 10).Select(i => new Project
            {
                 Name="Something"
            });
        public static IEnumerable<Customer> OneCustomer()
            => Enumerable.Range(0, 10).Select(i => new Customer
            {
                 RegistrationNumber="203300"
            });
        public static IEnumerable<Proposal> TenProposals
            => Enumerable.Range(0, 10).Select(i => new Proposal
            {
                Name = "Something"
            });
        public static IEnumerable<Invoice> TenInvoices
            => Enumerable.Range(0, 10).Select(i => new Invoice
            {
                 CustomerVAT="203300624"
            });
        public static IEnumerable<Programm> TenProgramms
            => Enumerable.Range(0, 10).Select(i => new Programm
            {
                ProgrammName="Horizon"
            });
    }
}

