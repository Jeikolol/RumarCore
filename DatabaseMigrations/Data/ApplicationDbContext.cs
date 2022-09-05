using Core.Entities;
using Core.Security;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Data
{
    public class ApplicationDbContext : DbContext
    {
        public LoginResult CurrentUser => ClaimsHelper.CurrentUser.UserData;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Loan>().ToTable("Loans");
            builder.Entity<TransactionType>().ToTable("TransactionTypes");
            builder.Entity<TransactionPayment>().ToTable("TransactionPayments");
            builder.Entity<ClientType>().ToTable("ClientTypes");
            builder.Entity<Beneficiary>().ToTable("Beneficiaries");
            builder.Entity<TaxType>().ToTable("TaxTypes");
            builder.Entity<RelationshipType>().ToTable("RelationshipTypes");
            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<BeneficiaryLoan>().ToTable("BeneficiaryLoans");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Loan>()
                .HasOne(x => x.Client)
                .WithOne(x => x.Loan);

            builder.Entity<BeneficiaryLoan>()
                .HasKey(t => new { t.BeneficiaryId, t.LoanId});

            builder.Entity<BeneficiaryLoan>()
                .HasOne(pt => pt.Loan)
                .WithMany(p => p.BeneficiaryLoan)
                .HasForeignKey(pt => pt.LoanId);

            builder.Entity<BeneficiaryLoan>()
                .HasOne(pt => pt.Beneficiary)
                .WithMany(t => t.BeneficiaryLoan)
                .HasForeignKey(pt => pt.BeneficiaryId);

            //builder.Entity<User>().HasData(
            //    new User()
            //    {
            //        Id = 1,
            //        Email = "admin@admin.com",
            //        FirstName = "Administrador",
            //        LastName = "",
            //        Address = "",
            //        Identification = "40228341968",
            //        PhoneNumber = "8298879669",
            //        UserName = "admin",
            //        Password = PasswordHashConstants.HashedAdministratorPassword,
            //        CreatedById = 1,
            //        CreatedOn = DateTime.UtcNow,
            //        IsDeleted = false,
            //    });

            //builder.Entity<RelationshipType>().HasData(
            //    new RelationshipType() { Id = 1, Name = "FAMILIAR", Description = "RELACION FAMILIAR", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1},
            //    new RelationshipType() { Id = 2, Name = "RELACIONADO", Description = "RELACIONADA", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1},
            //    new RelationshipType() { Id = 3, Name = "COMERCIAL", Description = "RELACION COMERCIAL", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1}
            //    );   

            //builder.Entity<Country>().HasData(
            //    new Country() { Id = 1, Code = "RD", Description = "REPUBLICA DOMINICANA", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1},
            //    new Country() { Id = 2, Code = "USA", Description = "ESTADOS UNIDOS", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1},
            //    new Country() { Id = 3, Code = "ESP", Description = "ESPAÑA", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1},
            //    new Country() { Id = 4, Code = "UK", Description = "REINO UNIDO", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1}
            //    );  

            //builder.Entity<TaxType>().HasData(
            //    new TaxType() { Id = 1, Code = "01", Name = "0%", Percentage = 0.0m, IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1},
            //    new TaxType() { Id = 2, Code = "02", Name = "18%", Percentage = 0.18m, IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1},
            //    new TaxType() { Id = 3, Code = "03", Name = "25%", Percentage = 0.25m, IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1},
            //    new TaxType() { Id = 4, Code = "04", Name = "50%", Percentage = 0.50m, IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1}
            //    );

            //builder.Entity<ClientType>().HasData(
            //    new ClientType() { Id = 1, Name = "RECURRENTE", Description = "CLIENTE RECURRENTE", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 },
            //    new ClientType() { Id = 2, Name = "RECOMENDADO", Description = "CLIENTE RECOMENDADO", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 },
            //    new ClientType() { Id = 3, Name = "NUEVO", Description = "CLIENTE NUEVO", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 }
            //); 

            //builder.Entity<TransactionType>().HasData(
            //    new TransactionType() { Id = 1, Name = "EFECTIVO", Description = "PAGO EN EFECTIVO", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 },
            //    new TransactionType() { Id = 2, Name = "TRANSFERENCIA", Description = "PAGO EN TRANSFERENCIA", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 },
            //    new TransactionType() { Id = 3, Name = "CHEQUE", Description = "PAGO EN CHEQUE", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 }
            //);

            //builder.Entity<TransactionPayment>().HasData(
            //    new TransactionPayment() { Id = 1, Name = "DIARIO", Description = "PAGO DIARIO", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 },
            //    new TransactionPayment() { Id = 2, Name = "QUINCENAL", Description = "PAGO QUINCENAL", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 },
            //    new TransactionPayment() { Id = 3, Name = "MENSUAL", Description = "PAGO MENSUAL", IsDeleted = false, CreatedOn = DateTime.UtcNow,  CreatedById = 1 }
            //);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<TransactionPayment> TransactionPayments { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<BeneficiaryLoan> BeneficiaryLoans { get; set; }

    }
}
