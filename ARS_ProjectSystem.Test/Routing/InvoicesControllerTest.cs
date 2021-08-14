namespace ARS_ProjectSystem.Test.Routing
{
    using ARS_ProjectSystem.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class InvoicesControllerTest
    {
        [Fact]
        public void GetCreateRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Invoices/CreateInvoice")
            .To<InvoicesController>(c => c.CreateInvoice());
        [Fact]
        public void GetAllRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Invoices/All")
            .To<InvoicesController>(c => c.All());
        
    }
}
