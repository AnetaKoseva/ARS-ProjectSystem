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

            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;
            var cache = DistributedCacheMocks.Cache;

            var projects = Enumerable
                .Range(0, 10)
                .Select(i => new Project());
            data.Projects.AddRange(projects);

            data.SaveChanges();

            var projectService = new ProjectService(data,mapper);
            var statisticsService = new StatisticsService(data);
            
            var homeController = new HomeController(statisticsService, projectService,cache);

            var result = homeController.Index();

            Assert.NotNull(result);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = viewResult.Model;
            var indexViewModel = Assert.IsType<IndexViewModel>(model);

            Assert.Equal(10, indexViewModel.TotalProjects);
        }

        [Fact]
        public void ErrorShouldReturnView()
        {
            var homeController = new HomeController(null,null,null);

            var result = homeController.Error();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
