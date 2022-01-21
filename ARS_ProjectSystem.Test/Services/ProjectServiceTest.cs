namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models;
    using ARS_ProjectSystem.Models.Projects;
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
            var count = result.Count();

            Assert.NotNull(result);
            Assert.Equal(1, count);
        }

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
            var count = result.Count();

            Assert.NotNull(result);
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

            var count = result.Count;

            Assert.NotNull(result);
            Assert.Equal(1, count);
            Assert.Equal("Horizon", result.Single());
        }

        [Fact]
        public void AllShouldReturnAllDataAndNotBeNull()
        {
            string programm = "Horizon";
            string searchTerm = "Aneta";
            ProjectSorting projectsorting=ProjectSorting.Status;
            int currentPage = 1;
            int projectsPerPage = 3;

            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            data.Projects.Add(new Project
            {
                Id = 1,
                ProgrammId = 1,
                Name = "ARS",
                CustomerRegistrationNumber = "99999999",
                ProjectPhoto = "https://imagga.com/static/images/content-moderation/dashboard.svg",
                Status = "started",
                StartDate = "14082021",
                EndDate = "14082023",
                ProjectRate = 2.5
            });

            data.Projects.Add(new Project
            {
                Id = 2,
                ProgrammId = 2,
                Name = "ARSConsult",
                CustomerRegistrationNumber = "8888888",
                ProjectPhoto = "https://imagga.com/static/images/content-moderation/dashboard.svg",
                Status = "finished",
                StartDate = "14082021",
                EndDate = "14082023",
                ProjectRate = 2.5
            });

            data.SaveChanges();

            var projectService = new ProjectService(data, mapper);
            var result = projectService.All(programm, searchTerm, projectsorting, currentPage, projectsPerPage);
            var count = result.ProjectsPerPage;

            Assert.NotNull(result);
            Assert.Equal(3, count);
        }

        [Fact]
        public void AllShouldReturnAllDataAndNotBeNullSortingProgramm()
        {
            string programm = "Horizon";
            string searchTerm = "Aneta";
            ProjectSorting projectsorting = ProjectSorting.Programm;
            int currentPage = 1;
            int projectsPerPage = 3;

            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            data.Projects.Add(new Project
            {
                Id = 1,
                ProgrammId = 1,
                Name = "ARS",
                CustomerRegistrationNumber = "99999999",
                ProjectPhoto = "https://imagga.com/static/images/content-moderation/dashboard.svg",
                Status = "started",
                StartDate = "14082021",
                EndDate = "14082023",
                ProjectRate = 2.5
            });

            data.Projects.Add(new Project
            {
                Id = 2,
                ProgrammId = 2,
                Name = "ARSConsult",
                CustomerRegistrationNumber = "8888888",
                ProjectPhoto = "https://imagga.com/static/images/content-moderation/dashboard.svg",
                Status = "finished",
                StartDate = "14082021",
                EndDate = "14082023",
                ProjectRate = 2.5
            });

            data.SaveChanges();

            var projectService = new ProjectService(data, mapper);
            var result = projectService.All(programm, searchTerm, projectsorting, currentPage, projectsPerPage);
            var count = result.ProjectsPerPage;

            Assert.NotNull(result);
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
            var project = new ProjectFormModel
            {
                  Id=1,
                 Name="ARS",
                 ProposalId=1,
                 ProjectPhoto="https://imagga.com/static/images/content-moderation/dashboard.svg",
                 Status="started",
                 StartDate="10082020",
                 EndDate="10082022",
                 ProjectRate=3,
                 ProgrammId=1,
                 CustomerRegistrationNumber="999999"
            };
            var result = projectService.Create(project);

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
            var project = new ProjectFormModel
            {
                 Id=2,
                 Name="ARS",
                 ProposalId=1,
                 ProjectPhoto="https://imagga.com/static/images/content-moderation/dashboard.svg",
                 Status="started",
                 StartDate="14082021",
                  EndDate="14082023",
                  ProjectRate=2.5,
                  CustomerRegistrationNumber="88888888"
            };
            var result = projectService.Edit(project);

            Assert.True(result);
        }
    }
}
