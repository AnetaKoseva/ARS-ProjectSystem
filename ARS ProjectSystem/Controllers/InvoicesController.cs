namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;



    public class InvoicesController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public InvoicesController(ProjectSystemDbContext data)
            => this.data = data;

        //[HttpPost]
        [Authorize]
        public IActionResult Add()//AddInvoiceFormModel invoice)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            //var invoiceData = new Invoice
            //{
            //    Id = invoice.Id,
            //    CreatedOn = invoice.CreatedOn,
            //    CustomerRegistrationNumber=invoice.FirmRegistrationNumber,
            //    DueDate=invoice.DueDate,
            //    IBAN=invoice.IBAN,
            //    Item=invoice.Item,
            //    Number=invoice.Number,
            //    PaymentMethod=invoice.PaymentMethod,
            //    Price=invoice.Price
            //};
            //this.data.Invoices.Add(invoiceData);
            //this.data.SaveChanges();

            //return RedirectToAction("Index", "Home");
            return View();
        }
    }
}
