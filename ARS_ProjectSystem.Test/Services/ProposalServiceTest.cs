﻿namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Services.Proposals;
    using ARS_ProjectSystem.Test.Mocks;
    using System.Linq;
    using Xunit;

    public class ProposalServiceTest
    {
        [Fact]
        public void AllShoudReturnAllProposals()
        {
            using var data = DatabaseMock.Instance;

            data.Proposals.Add(new Proposal
            {
                Name = "ARS"
            });

            data.SaveChanges();

            var proposalService = new ProposalService(data);
            var result = proposalService.All();
            var count = result.Count();

            Assert.NotNull(result);
            Assert.Equal(1, count);
        }

        [Fact]
        public void GetProposalCustomersShoulReturnAll()
        {
            using var data = DatabaseMock.Instance;

            data.Proposals.Add(new Proposal
            {
                Name = "ARS",
                CustomerRegistrationNumber = "99999"
            });

            data.Customers.Add(new Customer
            {
                RegistrationNumber = "99999",
                Name = "ARS"
            });

            data.SaveChanges();

            var proposalService = new ProposalService(data);
            var result = proposalService.GetProposalCustomers();
            var count = result.Count();

            Assert.NotNull(result);
            Assert.Equal(1, count);
        }

        [Fact]
        public void CreateProposalShoulReturnTrueData()
        {
            using var data = DatabaseMock.Instance;

            var proposalService = new ProposalService(data);

            var result = proposalService.Create(
                1,
                "Ars",
                "10082020",
                "https://imagga.com/static/images/content-moderation/dashboard.svg",
                3.5,
                "99999",
                1,
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx");

            var count = data.Proposals.Count();

            Assert.Equal(1, count);
            Assert.Equal(1, result);
        }

        [Fact]
        public void DetailsShoulReturnAll()
        {
            using var data = DatabaseMock.Instance;

            data.Proposals.Add(new Proposal
            {
                Id = 1,
                CustomerRegistrationNumber = "99999"
            });

            data.SaveChanges();

            var proposalService = new ProposalService(data);
            var result = proposalService.Details(1);
            
            Assert.NotNull( result);
        }

        [Fact]
        public void EditShouldReturnTrueData()
        {
            using var data = DatabaseMock.Instance;
            var proposalService = new ProposalService(data);

            var proposal=data.Proposals.Add(new Proposal
            {
                Id = 1,
                CustomerRegistrationNumber = "99999"
            });

            var result=proposalService.Edit(
            1,
                "xxx",
                "xxx",
                "xxx",
                3.2,
                "xxx",
                2,
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx",
                "xxx");

            proposal.Entity.CustomerRegistrationNumber = "xxxxxxx";

            Assert.True(result);
        }
    }
}
