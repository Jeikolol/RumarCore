using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RumarApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RumarApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<ClientViewModel>().ToTable("Clients");
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

        public DbSet<RumarApp.Models.ClientViewModel> Client { get; set; }

        public DbSet<RumarApp.Models.Loan> Loan { get; set; }
        public DbSet<RumarApp.Models.TransactionType> TransactionType { get; set; }
        public DbSet<RumarApp.Models.TransactionPayment> TransactionPayment { get; set; }
        public DbSet<RumarApp.Models.ClientType> ClientType { get; set; }
        public DbSet<RumarApp.Models.Beneficiary> Beneficiary { get; set; }
        public DbSet<RumarApp.Models.TaxType> TaxType { get; set; }
        public DbSet<RumarApp.Models.RelationshipType> RelationshipType { get; set; }
    }
}
