﻿namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Infrastructure;
    using ARS_ProjectSystem.Models.Invoices;
    using ARS_ProjectSystem.Services.Invoices;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    using static WebConstants;
    public class InvoicesController : Controller
    {
        private readonly ProjectSystemDbContext data;
        private readonly IInvoiceService invoices;
        private readonly IMapper mapper;
        public InvoicesController(ProjectSystemDbContext data, IInvoiceService invoices, IMapper mapper)
        {
            this.data = data;
            this.invoices = invoices;
            this.mapper = mapper;
        }
        [Authorize]
        public IActionResult All()
        {
            var invoiceData = this.invoices.All();

            return View(invoiceData);
        }
        public IActionResult AllCustomerInvoices(string id)
        {
            var invoiceData = this.invoices.AllCustomerInvoices(id);

            return View(invoiceData);
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
                CustomerAddress = customer.Address,
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

            var model = new InvoiceFormModel
            {
                Id=invoice.Id,
                Item = invoice.Item,
                CreatedOn = invoice.CreatedOn,
                DueDate = invoice.DueDate,
                CustomerRegistrationNumber = invoice.CustomerRegistrationNumber,
                CustomerVAT=invoice.CustomerVAT,
                CustomerAddress=invoice.CustomerAddress,
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
            var invoice = this.invoices.Details(id);
            var invoiceForm = this.mapper.Map<InvoiceFormModel>(invoice);

            return View(invoiceForm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(InvoiceFormModel invoice,int id)
        {
            var invoiceIsEdited = this.invoices.Edit(
            invoice.Id,
            invoice.Item,
            invoice.Number,
            invoice.Price,
            invoice.Quantity,
            invoice.CreatedOn,
            invoice.DueDate,
            invoice.Total);

            if (!invoiceIsEdited || !User.IsAdmin())
            {
                return BadRequest();
            }

            TempData[GlobalMessageKey] = $"You invoice {invoice.Id} is edited!";

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
             this.invoices.Delete(id);

            return RedirectToAction("All","Customers");
        }
    }
}
