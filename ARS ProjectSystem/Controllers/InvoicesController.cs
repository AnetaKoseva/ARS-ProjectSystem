namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Invoices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Globalization;
    using System.Linq;



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
                    Id = i.Id,
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
                CustomerVAT=customer.VAT,
                CustomerAdress=customer.Address,
                CustomerCountry=customer.Country,
                CustomerName=customer.Name,
                CustomerTown=customer.Town,
                CustomerOwnerName=customer.OwnerName,
                DueDate = invoice.DueDate,
                Item = invoice.Item,
                Number = invoice.Id,
                Quantity=invoice.Quantity,
                Price = invoice.Price,
                Total=invoice.Price*invoice.Number
            };
            this.data.Invoices.Add(invoiceData);
            this.data.SaveChanges();

            return RedirectToAction("Add", "Invoices",new {id=invoiceData.Id } );
        }

        [Authorize]
        public IActionResult Add(int id, string registrationNumber)
        {
            var invoice = this.data.Invoices.FirstOrDefault(i=>i.Id==id);
            
            var model = new InvoiceFormModel
            {
                Id=invoice.Id,
                Number = invoice.Number,
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
        public IActionResult Delete(int id)
        {
            var invoice= this.data.Invoices.FirstOrDefault(i => i.Id == id);
            this.data.Invoices.Remove(invoice);
            this.data.SaveChanges();
            return RedirectToAction(nameof(All));
        }
    }
}
