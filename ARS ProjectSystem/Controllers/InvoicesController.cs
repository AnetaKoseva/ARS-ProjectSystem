namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Invoices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;



    public class InvoicesController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public InvoicesController(ProjectSystemDbContext data)
            => this.data = data;
        [Authorize]
        public IActionResult CreateInvoice() => View();
        [Authorize]
        [HttpPost]
        public IActionResult CreateInvoice(AddInvoiceFormModel invoice,string id)
        {
            var customer = this.data.Customers.FirstOrDefault(c => c.RegistrationNumber == id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            var invoiceData = new Invoice
            {
                
                CreatedOn = invoice.CreatedOn,
                CustomerRegistrationNumber = customer.RegistrationNumber,
                DueDate = invoice.DueDate,
                IBAN = invoice.IBAN,
                Item = invoice.Item,
                Number = invoice.Number,
                PaymentMethod = invoice.PaymentMethod,
                Price = invoice.Price,
                Total=invoice.Price*invoice.Number
            };
            this.data.Invoices.Add(invoiceData);
            this.data.SaveChanges();

            return RedirectToAction("Add", "Invoices",new {id=invoiceData.Id } );
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            var invoice = this.data.Invoices.FirstOrDefault(i=>i.Id==id);
            var model = new AddInvoiceFormModel
            {
                Id = invoice.Id,
                Number = invoice.Number,
                PaymentMethod = invoice.PaymentMethod,
                Item = invoice.Item,
                CreatedOn = invoice.CreatedOn,
                DueDate = invoice.DueDate,
                CustomerRegistrationNumber = invoice.CustomerRegistrationNumber,
                IBAN = invoice.IBAN,
                Price = invoice.Price,
                Total = invoice.Total
            };
            return View(model);
        }
    }
}
