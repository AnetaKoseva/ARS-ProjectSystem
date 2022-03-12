namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Services.Invoices;
    using ARS_ProjectSystem.Services.Programms;
    using ARS_ProjectSystem.Test.Mocks;
    using System.Linq;
    using Xunit;

    public class InvoiceServiceTest
    {
        [Fact]
        public void AllShoudReturnAllInvoices()
        {
            using var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            data.Invoices.Add(new Invoice
            {
                 CustomerVAT = "203300624"
            });

            data.SaveChanges();

            var invoiceService = new InvoiceService(data);
            var result = invoiceService.All();
            var count = result.Count();
            var programmName = result.Select(p => p.CustomerVAT).ToList();

            Assert.NotNull(result);
            Assert.Equal(1, count);
            Assert.Equal("203300624", programmName[0]);
        }
        [Fact]
        public void AllCustomerInvoicesShoudReturnInvoicesForTheCustomer()
        {
            using var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            data.Invoices.Add(new Invoice
            {
                CustomerVAT = "203300624"
            });

            data.Invoices.Add(new Invoice
            {
                CustomerVAT = "9999999"
            });

            data.SaveChanges();

            var invoiceService = new InvoiceService(data);
            var result = invoiceService.AllCustomerInvoices("9999999");

            Assert.NotNull(result);
        }
    }
}
