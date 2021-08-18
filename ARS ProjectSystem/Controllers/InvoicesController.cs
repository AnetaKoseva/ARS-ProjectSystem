namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Invoices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    using static WebConstants;
    public class InvoicesController:Controller
    {
        private readonly ProjectSystemDbContext data;
        public InvoicesController(ProjectSystemDbContext data)
            => this.data = data;
        [Authorize]
        public IActionResult All()
        {
            var invoices = this.data
                .Invoices
                .Select(i=>new InvoiceFormModel 
                { 
                    Id=i.Id,
                 Number=i.Number,
                 CustomerName=i.CustomerName,
                 CustomerVAT=i.CustomerVAT,
                  Item=i.Item,
                  Quantity=i.Quantity,
                  Total=i.Total
                })
                .ToList();
            return View(invoices);
        }
        public IActionResult AllCustomerInvoices(string id)
        {
            var invoices = this.data
                .Invoices.Where(i=>i.CustomerRegistrationNumber==id)
                .Select(i => new InvoiceFormModel
                {
                    Id=i.Id,
                    Number = i.Number,
                    CustomerName = i.CustomerName,
                    CustomerVAT = i.CustomerVAT,
                    Item = i.Item,
                    Quantity = i.Quantity,
                    Total = i.Total
                })
                .ToList();

            return View(invoices);
        }

        [Authorize]
        public IActionResult CreateInvoice() => View();

        [Authorize]
        [HttpPost]
        public IActionResult CreateInvoice(InvoiceFormModel invoice,string id)
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
                CustomerVAT = customer.VAT,
                CustomerAdress = customer.Address,
                CustomerCountry = customer.Country,
                CustomerName = customer.Name,
                CustomerTown = customer.Town,
                CustomerOwnerName = customer.OwnerName,
                DueDate = invoice.DueDate,
                Number = invoice.Number,
                Item = invoice.Item,
                Quantity =invoice.Quantity,
                Price = invoice.Price,
                Total=invoice.Price*invoice.Quantity
            };

            this.data.Invoices.Add(invoiceData);
            this.data.SaveChanges();

            return RedirectToAction("Add", "Invoices",new {id=invoiceData.Id } );
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            var invoice = this.data.Invoices.FirstOrDefault(i=>i.Id==id);
            var invoiceNumber = (invoice.Id + 1).ToString(string.Format("E{0:000000}", 42));

            var model = new InvoiceFormModel
            {
                Id=invoice.Id,
                Number = invoiceNumber,
                Item = invoice.Item,
                CreatedOn = invoice.CreatedOn,
                DueDate = invoice.DueDate,
                CustomerRegistrationNumber = invoice.CustomerRegistrationNumber,
                CustomerVAT=invoice.CustomerVAT,
                CustomerAddress=invoice.CustomerAdress,
                CustomerOwner=invoice.CustomerOwnerName,
                Quantity=invoice.Quantity,
                CustomerName=invoice.CustomerName,
                Country=invoice.CustomerCountry,
                Town=invoice.CustomerTown,
                Price = invoice.Price,
                Total = invoice.Total
            };

            return View(model);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var invoices = this.data.Invoices.Where(i => i.Id == id)
                .Select(i => new InvoiceFormModel
                {
                    Id=i.Id,
                    Number = i.Number,
                    Item = i.Item,
                    CreatedOn = i.CreatedOn,
                    DueDate = i.DueDate,
                    Quantity = i.Quantity,
                    Price = i.Price,
                    Total = i.Total
                }).FirstOrDefault();

            return View(new InvoiceFormModel
            {
                Id = invoices.Id,
                Number = invoices.Number,
                Item = invoices.Item,
                CreatedOn = invoices.CreatedOn,
                DueDate = invoices.DueDate,
                Quantity = invoices.Quantity,
                Price = invoices.Price,
                Total = invoices.Total
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(InvoiceFormModel invoice,int id)
        {
            var invoiceData = this.data
                .Invoices
                .Find(id);

            invoiceData.Item = invoice.Item;
            invoiceData.Number = invoice.Number;
            invoiceData.Price = invoice.Price;
            invoiceData.Quantity = invoice.Quantity;
            invoiceData.CreatedOn = invoice.CreatedOn;
            invoiceData.DueDate = invoice.DueDate;

            this.data.SaveChanges();

            TempData[GlobalMessageKey] = $"You invoice {invoice.Id} is edited!";

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var invoice= this.data
                .Invoices
                .FirstOrDefault(i => i.Id == id);

            this.data.Invoices.Remove(invoice);
            this.data.SaveChanges();

            return RedirectToAction("All","Customers");
        }
    }
}
