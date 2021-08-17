namespace ARS_ProjectSystem.Test.Pipeline
{
    using ARS_ProjectSystem.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class InvoicesControllerTest
    {
        [Fact]
        public void GetCreateInvoiceShouldBeForAuthorizedUsersAndReturnView()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Invoices/CreateInvoice")
                    .WithUser())
                .To<InvoicesController>(c => c.CreateInvoice())
                .Which()
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();

        [Fact]
        public void GetAllShoulddReturnView()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Proposals/All")
                    .WithUser())
                .To<ProposalsController>(c => c.All())
                .Which()
                .ShouldReturn()
                .View();
    }
}
