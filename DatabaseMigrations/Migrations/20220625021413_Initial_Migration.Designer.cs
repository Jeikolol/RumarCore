﻿// <auto-generated />
using System;
using DatabaseMigrations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseMigrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220625021413_Initial_Migration")]
    partial class Initial_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Beneficiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Beneficiaries");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Core.Entities.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(359),
                            Description = "CLIENTE RECURRENTE",
                            IsDeleted = false,
                            Name = "RECURRENTE"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(363),
                            Description = "CLIENTE RECOMENDADO",
                            IsDeleted = false,
                            Name = "RECOMENDADO"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(364),
                            Description = "CLIENTE NUEVO",
                            IsDeleted = false,
                            Name = "NUEVO"
                        });
                });

            modelBuilder.Entity("Core.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "RD",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(8283),
                            Description = "REPUBLICA DOMINICANA",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            Code = "USA",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(8285),
                            Description = "ESTADOS UNIDOS",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            Code = "ESP",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(8287),
                            Description = "ESPAÑA",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            Code = "UK",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(8288),
                            Description = "REINO UNIDO",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Core.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Capital")
                        .HasColumnType("bigint");

                    b.Property<long>("CapitalToShow")
                        .HasColumnType("bigint");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ClientTypeId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFullPaid")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Quote")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RemainingPayments")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionPaymentId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("ClientTypeId");

                    b.HasIndex("TaxTypeId");

                    b.HasIndex("TransactionPaymentId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Core.Entities.RelationshipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RelationshipTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(7405),
                            Description = "RELACION FAMILIAR",
                            IsDeleted = false,
                            Name = "FAMILIAR"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(7413),
                            Description = "RELACIONADA",
                            IsDeleted = false,
                            Name = "RELACIONADO"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(7415),
                            Description = "RELACION COMERCIAL",
                            IsDeleted = false,
                            Name = "COMERCIAL"
                        });
                });

            modelBuilder.Entity("Core.Entities.TaxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TaxTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "01",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(9441),
                            IsDeleted = false,
                            Name = "0%",
                            Percentage = 0.0m
                        },
                        new
                        {
                            Id = 2,
                            Code = "02",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(9446),
                            IsDeleted = false,
                            Name = "18%",
                            Percentage = 0.18m
                        },
                        new
                        {
                            Id = 3,
                            Code = "03",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(9447),
                            IsDeleted = false,
                            Name = "25%",
                            Percentage = 0.25m
                        },
                        new
                        {
                            Id = 4,
                            Code = "04",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(9448),
                            IsDeleted = false,
                            Name = "50%",
                            Percentage = 0.50m
                        });
                });

            modelBuilder.Entity("Core.Entities.TransactionPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionPayments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1927),
                            Description = "PAGO DIARIO",
                            IsDeleted = false,
                            Name = "DIARIO"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1930),
                            Description = "PAGO QUINCENAL",
                            IsDeleted = false,
                            Name = "QUINCENAL"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1932),
                            Description = "PAGO MENSUAL",
                            IsDeleted = false,
                            Name = "MENSUAL"
                        });
                });

            modelBuilder.Entity("Core.Entities.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1152),
                            Description = "PAGO EN EFECTIVO",
                            IsDeleted = false,
                            Name = "EFECTIVO"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1155),
                            Description = "PAGO EN TRANSFERENCIA",
                            IsDeleted = false,
                            Name = "TRANSFERENCIA"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1157),
                            Description = "PAGO EN CHEQUE",
                            IsDeleted = false,
                            Name = "CHEQUE"
                        });
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "",
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2022, 6, 25, 2, 14, 13, 343, DateTimeKind.Utc).AddTicks(8743),
                            Email = "admin@admin.com",
                            FirstName = "Administrador",
                            Identification = "40228341968",
                            IsDeleted = false,
                            LastName = "",
                            Password = "1000:o/aziZjsVx7sr4RzrtPHNs2AkP5LGuhH:txBYU1u3kkEktiP64gKan99vXohED85c",
                            PhoneNumber = "8298879669",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("BeneficiaryLoan", b =>
                {
                    b.HasOne("Core.Entities.Beneficiary", null)
                        .WithMany()
                        .HasForeignKey("BeneficiariesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Loan", null)
                        .WithMany()
                        .HasForeignKey("LoansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Beneficiary", b =>
                {
                    b.HasOne("Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.HasOne("Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.Loan", b =>
                {
                    b.HasOne("Core.Entities.Client", "Client")
                        .WithOne("Loan")
                        .HasForeignKey("Core.Entities.Loan", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ClientType", "ClientType")
                        .WithMany()
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TaxType", "TaxType")
                        .WithMany()
                        .HasForeignKey("TaxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TransactionPayment", "TransactionPayment")
                        .WithMany()
                        .HasForeignKey("TransactionPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ClientType");

                    b.Navigation("TaxType");

                    b.Navigation("TransactionPayment");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.Navigation("Loan");
                });
#pragma warning restore 612, 618
        }
    }
}