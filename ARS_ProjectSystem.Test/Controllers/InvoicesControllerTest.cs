namespace ARS_ProjectSystem.Test.Controllers
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using ARS_ProjectSystem.Controllers;
    using FluentAssertions;
    using ARS_ProjectSystem.Models.Invoices;
    using System.Collections.Generic;

    using static Data.ProjectSystem;

    public class InvoicesControllerTest
    {
        [Fact]
        public void AllActionShouldReturnCorrectViewWithModel()
            => MyController<InvoicesController>
            .Instance(instance => instance
            .WithData(TenInvoices))
            .Calling(c => c.All())
            .ShouldHave()
            .ActionAttributes(attributes => attributes
                                 .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<List<InvoiceFormModel>>().Passing(p => p.Should().HaveCount(10)));

        [Fact]
        public void CreateInvoiceActionShouldReturnCorrectViewWithModel()
           => MyController<InvoicesController>
           .Instance(instance => instance
           .WithData(TenInvoices))
           .Calling(c => c.CreateInvoice())
           .ShouldHave()
           .ActionAttributes(attributes => attributes
                                .RestrictingForAuthorizedRequests())
           .AndAlso()
           .ShouldReturn()
           .View();
    }
}
