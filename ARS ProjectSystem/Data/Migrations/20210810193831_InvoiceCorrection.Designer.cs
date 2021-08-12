﻿namespace ARS_ProjectSystem.Data.Migrations
{
    using System;
    using ARS_ProjectSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    [DbContext(typeof(ProjectSystemDbContext))]
    [Migration("20210810193831_InvoiceCorrection")]
    partial class InvoiceCorrection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Customer", b =>
                {
                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VAT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegistrationNumber");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerRegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jobtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRegistrationNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerRegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerTown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DueDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Item")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRegistrationNumber");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Programm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Programms");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerRegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProgrammId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProjectRate")
                        .HasColumnType("float");

                    b.Property<int?>("ProposalId")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRegistrationNumber");

                    b.HasIndex("ProgrammId");

                    b.HasIndex("ProposalId")
                        .IsUnique()
                        .HasFilter("[ProposalId] IS NOT NULL");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abstract")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double>("Budget")
                        .HasColumnType("float");

                    b.Property<string>("CreatedOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerRegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FeatureKnowledge1")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FeatureKnowledge2")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FeatureName1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FeatureName2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FeatureTechnology1")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FeatureTechnology2")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FreeKeyword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullProposalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowProblemIsSolved")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keyword1Child")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keyword1Parent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keyword2Child")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keyword2Parent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keyword3Child")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keyword3Parent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProblemSolve")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ProjectAcronym")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectPurpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionDescribtion")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("SolutionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRegistrationNumber");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerRegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRegistrationNumber");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("EmployeeProposal", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("ProposalsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "ProposalsId");

                    b.HasIndex("ProposalsId");

                    b.ToTable("EmployeeProposal");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Employee", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.Customer", "Customer")
                        .WithMany("Employees")
                        .HasForeignKey("CustomerRegistrationNumber");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Invoice", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerRegistrationNumber")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Project", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.Customer", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerRegistrationNumber")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ARS_ProjectSystem.Data.Models.Programm", "Programm")
                        .WithMany("Projects")
                        .HasForeignKey("ProgrammId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARS_ProjectSystem.Data.Models.Proposal", "Proposal")
                        .WithOne("Project")
                        .HasForeignKey("ARS_ProjectSystem.Data.Models.Project", "ProposalId");

                    b.Navigation("Customer");

                    b.Navigation("Programm");

                    b.Navigation("Proposal");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Proposal", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.Customer", "Customer")
                        .WithMany("Proposals")
                        .HasForeignKey("CustomerRegistrationNumber");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.User", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.Customer", null)
                        .WithMany("Users")
                        .HasForeignKey("CustomerRegistrationNumber");
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARS_ProjectSystem.Data.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeProposal", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARS_ProjectSystem.Data.Models.Proposal", null)
                        .WithMany()
                        .HasForeignKey("ProposalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARS_ProjectSystem.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ARS_ProjectSystem.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Customer", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Invoices");

                    b.Navigation("Projects");

                    b.Navigation("Proposals");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Programm", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ARS_ProjectSystem.Data.Models.Proposal", b =>
                {
                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
