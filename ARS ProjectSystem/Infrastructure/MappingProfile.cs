namespace ARS_ProjectSystem.Infrastructure
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Models.Projects;
    using ARS_ProjectSystem.Services.Projects;
    using AutoMapper;

    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Project, ProjectServiceModel>()
                .ForMember(c=>c.ProgrammName,cfg=>cfg.MapFrom(c=>c.Programm.ProgrammName))
                .ForMember(c=>c.CustomerRegistrationNumber, cfg=>cfg.MapFrom(c=>c.Customer.Name));
            this.CreateMap<Project,ProjectIndexViewModel >();
            this.CreateMap<ProjectServiceModel, ProjectFormModel>();
            //Reverce mapping other side
        }
    }
}
