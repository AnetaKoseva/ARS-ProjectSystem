namespace ARS_ProjectSystem.Services.Programms
{
    using ARS_ProjectSystem.Models.Programms;
    using System.Collections.Generic;

    public interface IProgrammService
    {
        public IEnumerable<ProgrammServiceModel> All();

        public int Create(AddProgrammFormModel programm);
        public int Delete(int id);
    }
}
