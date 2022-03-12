namespace ARS_ProjectSystem.Services.Contracts
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Contracts;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ContractService :IContractService
    {
        private readonly ProjectSystemDbContext data;

        public ContractService(ProjectSystemDbContext data)
        {
            this.data = data;
        }
        public IEnumerable<ContractServiceModel> All()
        => this.data
                .Contracts
                .Select(c => new ContractServiceModel
                {
                    Id = c.Id,
                     Customer=new CustomerContractServiseModel 
                     {
                      RegistrationNumber = c.Customer.RegistrationNumber,
                      Email =c.Customer.Email,
                      Address=c.Customer.Address,
                      Country=c.Customer.Country,
                      Name=c.Customer.Name,
                      OwnerName=c.Customer.OwnerName,
                      PhoneNumber=c.Customer.PhoneNumber,
                      Town=c.Customer.Town,
                      Url=c.Customer.Url,
                      VAT=c.Customer.VAT
                     },
                      CreatedOn=c.CreatedOn,
                      DueDate=c.DueDate,
                      Price=c.Price,
                      Product=c.Product
                })
                .ToList();

        public IEnumerable<ContractServiceModel> AllCustomerContracts(string id)
        => this.data
                .Contracts.Where(i => i.Customer.RegistrationNumber == id)
                .Select(c => new ContractServiceModel
                {
                    Id = c.Id,
                    Customer = new CustomerContractServiseModel
                    {
                        RegistrationNumber = c.Customer.RegistrationNumber,
                        Email = c.Customer.Email,
                        Address = c.Customer.Address,
                        Country = c.Customer.Country,
                        Name = c.Customer.Name,
                        OwnerName = c.Customer.OwnerName,
                        PhoneNumber = c.Customer.PhoneNumber,
                        Town = c.Customer.Town,
                        Url = c.Customer.Url,
                        VAT = c.Customer.VAT
                    },
                    CreatedOn = c.CreatedOn,
                    DueDate = c.DueDate,
                    Price = c.Price,
                    Product = c.Product
                })
                .ToList();
        public ContractServiceModel Details(int id)
      => this.data
          .Contracts
          .Where(p => p.Id == id)
          .Select(c => new ContractServiceModel
          {
              Customer = new CustomerContractServiseModel
              {
                  RegistrationNumber = c.Customer.RegistrationNumber,
                  Email = c.Customer.Email,
                  Address = c.Customer.Address,
                  Country = c.Customer.Country,
                  Name = c.Customer.Name,
                  OwnerName = c.Customer.OwnerName,
                  PhoneNumber = c.Customer.PhoneNumber,
                  Town = c.Customer.Town,
                  Url = c.Customer.Url,
                  VAT = c.Customer.VAT
              },
              CreatedOn = c.CreatedOn,
              DueDate = c.DueDate,
              Price = c.Price,
              Product = c.Product
          })
           .FirstOrDefault();


        public bool Edit(ContractFormModel contract)
        {
            var contractData = this.data.Contracts.Find(contract.Id);

            contractData.Customer = contract.Customer;
            contractData.Product = contract.Product;
            contractData.Price = contract.Price;
            contractData.AdvancePrice = contract.AdvancePrice;
            contractData.CreatedOn = contract.CreatedOn;
            contractData.DueDate = contract.DueDate;
            
            this.data.SaveChanges();

            return true;
        }

        public int Delete(int id)
        {
            var contract = this.data.Contracts.FirstOrDefault(p => p.Id == id);

            this.data.Remove(contract);
            this.data.SaveChanges();
            return contract.Id;
        }

        public ContractServiceModel Add(int id)
        {
            var contract = this.data.Contracts.FirstOrDefault(i => i.Id == id);
           
            var model = new ContractServiceModel
            { 
                Id=contract.Id,
                Customer= new CustomerContractServiseModel
            {
                    RegistrationNumber = contract.CustomerRegistrationNumber,
                    Email = contract.CustomerEmail,
                    Address = contract.CustomerAddress,
                    Country = contract.CustomerCountry,
                    Name = contract.CustomerName,
                    OwnerName = contract.CustomerOwnerName,
                    PhoneNumber = contract.CustomerPhoneNumber,
                    Town = contract.CustomerTown,
                    Url = contract.CustomerUrl,
                    VAT = contract.CustomerVAT
                },
                 AdvancePrice=contract.AdvancePrice,
                Product = contract.Product,
                CreatedOn = contract.CreatedOn,
                DueDate = contract.DueDate,
                Price = contract.Price
            };
            
            return model;
        }

        public int Create(ContractFormModel contract, string id)
        {
            var customer = this.data.Customers.FirstOrDefault(c => c.RegistrationNumber == id);
            var contractData = new Contract
            {   
                 Price =contract.Price,
                 Product=contract.Product,
                 Customer=customer,
                 CustomerRegistrationNumber=customer.RegistrationNumber,
                 CustomerAddress=customer.Address,
                 CustomerCountry=customer.Country,
                 CustomerName=customer.Name,
                 CustomerOwnerName=customer.OwnerName,
                 CustomerTown=customer.Town,
                 CustomerVAT=customer.VAT,
                 CustomerEmail=customer.Email,
                  AdvancePrice=contract.AdvancePrice,
                 CreatedOn =contract.CreatedOn,
                 DueDate= contract.DueDate,
            };

            this.data.Contracts.Add(contractData);
            this.data.SaveChanges();
            return contractData.Id;
        }

    }
}
