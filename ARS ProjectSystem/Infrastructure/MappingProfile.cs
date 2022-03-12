﻿namespace ARS_ProjectSystem.Infrastructure
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Contracts;
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Models.Invoices;
    using ARS_ProjectSystem.Models.Projects;
    using ARS_ProjectSystem.Models.Proposals;
    using ARS_ProjectSystem.Services.Contracts;
    using ARS_ProjectSystem.Services.Invoices;
    using ARS_ProjectSystem.Services.Projects;
    using ARS_ProjectSystem.Services.Proposals;
    using AutoMapper;

    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Project, ProjectServiceModel>()
                .ForMember(c=>c.ProgrammName,cfg=>cfg.MapFrom(c=>c.Programm.ProgrammName))
                .ForMember(c=>c.CustomerRegistrationNumber, cfg=>cfg.MapFrom(c=>c.Customer.Name));

            this.CreateMap<Project,ProjectTotalServiceModel >();

            this.CreateMap<ProjectServiceModel, ProjectFormModel>();
            this.CreateMap<Invoice, InvoiceServiceModel>();

            this.CreateMap<ProposalServiceModel, ProposalFormModel>();
            this.CreateMap<InvoiceServiceModel, InvoiceFormModel>();
            this.CreateMap<ContractServiceModel, ContractFormModel>();
        }
    }
}
