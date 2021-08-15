namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Test.Mocks;
    using System.Linq;
    using Xunit;

    public class ProjectServiceTest
    {
        [Fact]
        public void GetProjectProposalsShoudReturnNotNull()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            data.Projects.Add(new Project
            {
                Id = 1,
                Name = "ARS",
            });
            data.Proposals.Add(new Proposal
            {
                Name = "ARS",
                ProjectId = 1
            });
            data.SaveChanges();
            var projectService = new ProjectService(data, mapper);
            var result = projectService.GetProjectProposals();
            Assert.NotNull(result);
        }
        [Fact]
        public void GetProjectCustomerssShoudReturnNotNull()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            data.Projects.Add(new Project
            {
                Id = 1,
                Name = "ARS",
                CustomerRegistrationNumber = "99999999"
            });
            data.Customers.Add(new Customer
            {
                Name = "ARS",
                RegistrationNumber = "99999999"
            });
            data.SaveChanges();
            var projectService = new ProjectService(data, mapper);
            var result = projectService.GetProjectCustomers();
            Assert.NotNull(result);
        }
        [Fact]
        public void GetProjectProgrammsShoudReturnNotNull()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            data.Projects.Add(new Project
            {
                ProgrammId = 1,
                Name = "ARS",
                CustomerRegistrationNumber = "99999999"
            });
            data.Programms.Add(new Programm
            {
                Id = 1,
                ProgrammName = "Horizon"
            });
            data.SaveChanges();
            var projectService = new ProjectService(data, mapper);
            var result = projectService.GetProjectProgramms();
            Assert.NotNull(result);
            var count = result.Count();
            Assert.Equal(1, count);
        }
        //Total
        [Fact]
        public void TotalShoudReturnNotNull()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            data.Projects.Add(new Project
            {
                ProgrammId = 1,
                Name = "ARS",
                CustomerRegistrationNumber = "99999999"
            });

            data.SaveChanges();
            var projectService = new ProjectService(data, mapper);
            var result = projectService.Total();
            Assert.NotNull(result);
            var count = result.Count();
            Assert.Equal(1, count);
        }
        [Fact]
        public void AllProjectProgrammsShoudReturnNotNull()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            data.Projects.Add(new Project
            {
                ProgrammId = 1,
                Name = "ARS",
                CustomerRegistrationNumber = "99999999"
            });
            data.Programms.Add(new Programm
            {
                Id = 1,
                ProgrammName = "Horizon",
                Description = "blabla",
                Url = "http:\\ars-consult.eu"
            });
            data.SaveChanges();

            var projectService = new ProjectService(data, mapper);
            var result = projectService.AllProjectProgramms().ToList();

            Assert.NotNull(result);

            var count = result.Count();
            Assert.Equal(1, count);

            Assert.Equal("Horizon", result.Single());
        }
        [Fact]
        public void AllShouldReturnAllDataAndNotBeNull()
        {
            string programm = "Horizon";
            string searchTerm = "Aneta";
            ProjectSorting projectsorting = 0;
            int currentPage = 1;
            int projectsPerPage = 3;

            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            data.Projects.Add(new Project
            {
                Id = 2,
                ProgrammId = 1,
                Name = "ARS",
                CustomerRegistrationNumber = "99999999",
                ProjectPhoto = "https://imagga.com/static/images/content-moderation/dashboard.svg",
                Status = "started",
                StartDate = "14082021",
                EndDate = "14082023",
                ProjectRate = 2.5
            });

            data.SaveChanges();

            var projectService = new ProjectService(data, mapper);
            var result = projectService.All(programm, searchTerm, projectsorting, currentPage, projectsPerPage);

            Assert.NotNull(result);
            var count = result.ProjectsPerPage;
            Assert.Equal(3, count);
        }
        [Fact]
        public void ProposalExistShouldBeTrue()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            data.Proposals.Add(new Proposal
            {
                Id = 1
            });

            data.SaveChanges();

            var projectService = new ProjectService(data, mapper);
            var result = projectService.ProposalExists(1);
            Assert.True(result);
        }
        [Fact]
        public void ProposalExistShouldBeFalse()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            data.Proposals.Add(new Proposal
            {
                Id = 1
            });

            data.SaveChanges();

            var projectService = new ProjectService(data, mapper);
            var result = projectService.ProposalExists(2);
            Assert.False(result);
        }
        [Fact]
        public void CreateShouldReturnDataAndMustBeTrue()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            var projectService = new ProjectService(data, mapper);
            var result = projectService.Create(1,
                "ARS",
                1,
                "https://imagga.com/static/images/content-moderation/dashboard.svg",
                "started",
                "10082020",
                "10082022",
                3,
                1,
                "999999");
            var count = data.Projects.Count();
            Assert.Equal(1, count);
            Assert.Equal(1, result);
        }
            [Fact]
        public void EditShouldReturnDataAndMustBeTrue()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            
            data.Projects.Add(new Project
            {
                Id = 2,
                ProgrammId = 1,
                Name = "ARS",
                CustomerRegistrationNumber = "99999999",
                ProjectPhoto = "https://imagga.com/static/images/content-moderation/dashboard.svg",
                Status = "started",
                StartDate = "14082021",
                EndDate = "14082023",
                ProjectRate = 2.5
            });
            var projectService = new ProjectService(data, mapper);
            var result = projectService.Edit(2,
                "ARS",
                1,
                "https://imagga.com/static/images/content-moderation/dashboard.svg",
                "started",
                "14082021",
                 "14082023",
                 2.5,
                 "88888888");

            Assert.True(result);
        }
    }
}
