namespace ARS_ProjectSystem.Test.Services
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Programms;
    using ARS_ProjectSystem.Services.Programms;
    using ARS_ProjectSystem.Test.Mocks;
    using System.Linq;
    using Xunit;

    public class ProgrammServiseTest
    {
        [Fact]
        public void AllShoudReturnAllProgramms()
        {
            using var data = DatabaseMock.Instance;

            data.Programms.Add(new Programm
            {
                ProgrammName = "ARS"
            });

            data.SaveChanges();

            var programmService = new ProgrammService(data);
            var result = programmService.All();
            var count = result.Count();
            var programmName = result.Select(p => p.ProgrammName).ToList();

            Assert.NotNull(result);
            Assert.Equal(1, count);
            Assert.Equal("ARS", programmName[0]);
        }

        [Fact]
        public void CreateProgrammShoulReturnTrueData()
        {
            using var data = DatabaseMock.Instance;

            var programmService = new ProgrammService(data);
            var programm = new AddProgrammFormModel
            {

                ProgrammName="Horizon",
                 Url="https://ec.europa.eu/programmes/horizon2020/en/home",
                 Description="blablabla"
            };
            var result = programmService.Create(programm);

            var count = data.Programms.Count();

            Assert.Equal(1, count);
            Assert.Equal(1, result);
        }
        [Fact]
        public void DeleteProgrammShoulReturnTrueData()
        {
            using var data = DatabaseMock.Instance;

            data.Programms.Add(new Programm
            {
                Id=1,
                ProgrammName = "ARS"
            });

            data.Programms.Add(new Programm
            {
                Id = 2,
                ProgrammName = "ARSConsult"
            });

            data.SaveChanges();

            var programmService = new ProgrammService(data);
            var result = programmService.Delete(1);
            var count = data.Programms.Count();

            Assert.Equal(1, count);
        }
    }
}
