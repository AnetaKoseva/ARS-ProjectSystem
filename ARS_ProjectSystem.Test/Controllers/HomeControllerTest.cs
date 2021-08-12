namespace ARS_ProjectSystem.Test.Controllers
{
    using ARS_ProjectSystem.Controllers;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Statistics;
    using ARS_ProjectSystem.Test.Mocks;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;
    public class HomeControllerTest
    {
        [Fact]//integrationtest
        public void IndexShoudReturnViewWithCorrectController()
        {
            //Arrange
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            var projects = Enumerable
                .Range(0, 10)
                .Select(i => new Project());
            data.Projects.AddRange(projects);

            data.SaveChanges();

            var projectService = new ProjectService(data,mapper);
            var statisticsService = new StatisticsService(data);
            var homeController = new HomeController(statisticsService, projectService);
            //Act
            var result = homeController.Index();
            //result
            //    .Should()
            //    .NotBeNull()
            //    .And.Should().BeAssignableTo<ViewResult>()
            //    .Which
            //    .Model
            //    .As<IndexViewModel>()
            //    .Should()
            //    .Match((IndexViewModel r) => r.TotalProjects == 10);
            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = viewResult.Model;
            var indexViewModel = Assert.IsType<IndexViewModel>(model);
            Assert.Equal(10, indexViewModel.TotalProjects);
        }

        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arrange
            var homeController = new HomeController(null,null);
            //Act
            var result = homeController.Error();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
