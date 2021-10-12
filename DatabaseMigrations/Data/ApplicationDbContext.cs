using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RumarApp.Data
{
    public class ApplicationDbContext : DbContext
    {
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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
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
    }
}
