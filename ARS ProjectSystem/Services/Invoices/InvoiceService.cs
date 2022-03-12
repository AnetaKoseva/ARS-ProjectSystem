﻿namespace ARS_ProjectSystem.Services.Invoices
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Invoices;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class InvoiceService : IInvoiceService
    {
        private readonly ProjectSystemDbContext data;

        public InvoiceService(ProjectSystemDbContext data)
        {
            this.data = data;
        }
        public IEnumerable<InvoiceServiceModel> All()
        => this.data
                .Invoices
                .Select(i => new InvoiceServiceModel
                {
                    Id = i.Id,
                    Number = i.Number,
                    CustomerName = i.CustomerName,
                    CustomerVAT = i.CustomerVAT,
                    Item = i.Item,
                    Quantity = i.Quantity,
                    Total = i.Total
                })
                .ToList();

        public IEnumerable<InvoiceServiceModel> AllCustomerInvoices(string id)
        => this.data
                .Invoices.Where(i => i.CustomerRegistrationNumber == id)
                .Select(i => new InvoiceServiceModel
                {
                    Id = i.Id,
                    Number = i.Number,
                    CustomerName = i.CustomerName,
                    CustomerVAT = i.CustomerVAT,
                    Item = i.Item,
                    Quantity = i.Quantity,
                    Total = i.Total
                })
                .ToList();
        public InvoiceFormModel Details(int id)
        {
            var invoice = this.data.Invoices.FirstOrDefault(i => i.Id == id);
            var model = new InvoiceFormModel
            {
                Id = invoice.Id,
                Number = invoice.Number,
                Item = invoice.Item,
                CreatedOn = invoice.CreatedOn,
                DueDate = invoice.DueDate,
                CustomerRegistrationNumber = invoice.CustomerRegistrationNumber,
                CustomerVAT = invoice.CustomerVAT,
                CustomerAddress = invoice.CustomerAddress,
                CustomerOwner = invoice.CustomerOwnerName,
                Quantity = invoice.Quantity,
                CustomerName = invoice.CustomerName,
                Country = invoice.CustomerCountry,
                Town = invoice.CustomerTown,
                Price = invoice.Price,
                Total = invoice.Total
            };

            return model;
        }


        public bool Edit(InvoiceFormModel invoice)
        {
            var invoiceData = this.data.Invoices.Find(invoice.Id);

            invoiceData.Item = invoice.Item;
            invoiceData.Number = invoice.Number;
            invoiceData.Price = invoice.Price;
            invoiceData.Quantity = invoice.Quantity;
            invoiceData.CreatedOn = invoice.CreatedOn;
            invoiceData.DueDate = invoice.DueDate;
            invoiceData.Total = invoice.Price * invoice.Quantity;

            this.data.SaveChanges();

            return true;
        }

        public int Delete(int id)
        {
            var invoice = this.data.Invoices.FirstOrDefault(p => p.Id == id);

            this.data.Remove(invoice);
            this.data.SaveChanges();
            return invoice.Id;
        }

        public InvoiceFormModel Add(int id)
        {
            var invoice = this.data.Invoices.FirstOrDefault(i => i.Id == id);
            var numberId = id.ToString().Length;
            var nullCount = 9 - numberId;
            string nullString = new string('0', nullCount);
            string invoiceNumber = $"{nullString}" + $"{id}";
            string result = numberId == 10 ? id.ToString() : "1" + $"{invoiceNumber}";
            invoice.Number = result;
            this.data.SaveChanges();

            var model = new InvoiceFormModel
            {
                Id = invoice.Id,
                Number = result,
                Item = invoice.Item,
                CreatedOn = invoice.CreatedOn,
                DueDate = invoice.DueDate,
                CustomerRegistrationNumber = invoice.CustomerRegistrationNumber,
                CustomerVAT = invoice.CustomerVAT,
                CustomerAddress = invoice.CustomerAddress,
                CustomerOwner = invoice.CustomerOwnerName,
                Quantity = invoice.Quantity,
                CustomerName = invoice.CustomerName,
                Country = invoice.CustomerCountry,
                Town = invoice.CustomerTown,
                Price = invoice.Price,
                Total = invoice.Total
            };

            return model;
        }

        public int Create(InvoiceFormModel invoice, string id)
        {
            var customer = this.data.Customers.FirstOrDefault(c => c.RegistrationNumber == id);

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
                Quantity = invoice.Quantity,
                Price = invoice.Price,
                Total = invoice.Price * invoice.Quantity
            };


            this.data.Invoices.Add(invoiceData);
            this.data.SaveChanges();
            return invoiceData.Id;
        }

        public int CreateAdvanceInvoice(int id)
        {
            var contract = this.data.Contracts.FirstOrDefault(c => c.Id == id);

            var invoiceData = new Invoice
            {
                CreatedOn = contract.CreatedOn,
                CustomerRegistrationNumber = contract.CustomerRegistrationNumber,
                CustomerVAT = contract.CustomerVAT,
                CustomerAddress = contract.CustomerAddress,
                CustomerCountry = contract.CustomerCountry,
                CustomerName = contract.CustomerName,
                CustomerTown = contract.CustomerTown,
                CustomerOwnerName = contract.CustomerOwnerName,
                DueDate = contract.DueDate,
                Item = contract.Product,
                Quantity = 1,
                Price = contract.AdvancePrice,
                Total = contract.AdvancePrice
            };

            this.data.Invoices.Add(invoiceData);
            this.data.SaveChanges();
            return invoiceData.Id;
        }

        public int CreateContractInvoice(int id)
        {
            var contract = this.data.Contracts.FirstOrDefault(c => c.Id == id);

            var invoiceData = new Invoice
            {
                CreatedOn = contract.CreatedOn,
                CustomerRegistrationNumber = contract.CustomerRegistrationNumber,
                CustomerVAT = contract.CustomerVAT,
                CustomerAddress = contract.CustomerAddress,
                CustomerCountry = contract.CustomerCountry,
                CustomerName = contract.CustomerName,
                CustomerTown = contract.CustomerTown,
                CustomerOwnerName = contract.CustomerOwnerName,
                DueDate = contract.DueDate,
                Item = contract.Product,
                Quantity = 1,
                Price = contract.Price,
                Total = contract.Price
            };

            this.data.Invoices.Add(invoiceData);
            this.data.SaveChanges();
            return invoiceData.Id;
        }
    }
}
