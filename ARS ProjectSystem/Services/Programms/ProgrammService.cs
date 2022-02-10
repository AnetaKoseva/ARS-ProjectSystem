namespace ARS_ProjectSystem.Services.Programms
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Programms;
    using System.Collections.Generic;
    using System.Linq;

    public class ProgrammService: IProgrammService
    {
        private readonly ProjectSystemDbContext data;

        public ProgrammService(ProjectSystemDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<ProgrammServiceModel> All()
            =>this.data.Programms.Select(p => new ProgrammServiceModel
            {
                Id = p.Id,
                ProgrammName = p.ProgrammName,
                Description = p.Description,
                Url = p.Url
            }).ToList();

        public int Create(AddProgrammFormModel programm)
        {
            var programmData = new Programm
            {
                ProgrammName = programm.ProgrammName,
                Url = programm.Url,
                Description = programm.Description
            };

            this.data.Programms.Add(programmData);
            this.data.SaveChanges();
            return programmData.Id;
        }

        public int Delete(int id)
        {
            var programm = this.data.Programms.FirstOrDefault(p => p.Id == id);

            this.data.Remove(programm);
            this.data.SaveChanges();
            return programm.Id;
        }
    }
}
