using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using DatabaseMigrations.Data;
using Microsoft.EntityFrameworkCore;
using RumarApp.Infraestructure;
using RumarApp.Models;
using RumarApp.Parameters;

namespace RumarApp.Services
{
    public class LoanService: Service, ILoanService
    {
        public LoanService(ApplicationDbContext database) : base(database)
        {
        }

        public async Task<ServiceResult<List<LoanModel>>> GetAll()
        {
            var result = ServiceResult<List<LoanModel>>.Create();

            var loans = await Database.Loans
                .Include(x => x.TaxType)
                .Select(x=> new LoanModel
                {
                    Id = x.Id,
                    Capital = x.Capital,
                    TaxTypeId = x.TaxTypeId,
                    TaxType = new TaxTypeModel
                    {
                        Name = x.TaxType.Name,
                        Percentage = x.TaxType.Percentage
                    },
                    Quote = x.Quote,
                    TransactionPaymentId = x.TransactionPaymentId,
                    ClientId = x.ClientId,
                    Client = new ClientViewModel
                    {
                        FirstName = x.Client.FirstName,
                        LastName = x.Client.LastName
                    },
                    ClientTypeId = x.ClientTypeId
                })
                .ToListAsync();

            result.Data = loans;

            return result;
        } 
        
        public async Task<ServiceResult<LoanModel>> GetDetailById(int id)
        {
            var result = ServiceResult<LoanModel>.Create();

            var loans = await Database.Loans
                .Include(x => x.TaxType)
                .Include(x => x.Client)
                .Where(x=> x.Id == id)
                .Select(x=> new LoanModel
                {
                    Id = x.Id,
                    Capital = x.Capital,
                    CapitalToShow = x.CapitalToShow,
                    TaxTypeId = x.TaxTypeId,
                    TaxType = new TaxTypeModel
                    {
                        Name = x.TaxType.Name,
                        Percentage = x.TaxType.Percentage
                    },
                    Quote = x.Quote,
                    TransactionPaymentId = x.TransactionPaymentId,
                    ClientId = x.ClientId,
                    ClientTypeId = x.ClientTypeId,
                    CreatedOn = x.CreatedOn,
                    Client = new ClientViewModel
                    {
                        Id = x.ClientId,
                        FirstName = x.Client.FirstName,
                        LastName = x.Client.LastName
                    },
                    Notes = x.Notes,
                    TransactionTypeId = x.TransactionTypeId, 
                    RemainingPayments = x.RemainingPayments,
                    Beneficiary = x.BeneficiaryLoan.Select(b => new BeneficiaryModel
                    {
                        FirstName = b.Beneficiary.FirstName,
                        LastName = b.Beneficiary.LastName
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            result.Data = loans;

            return result;
        }

        public async Task<ServiceResult<LoanModel>> Create(CreateLoansModel param)
        {
            var result = ServiceResult<LoanModel>.Create();

            var exist = await Database.Loans
                .AnyAsync(x => x.ClientId == param.Loan.ClientId);

            if (exist)
            {
                result.AddErrorMessage("El cliente seleccionado ya tiene un Prestamo Activo.");
                return result;
            }

            var loan = new Loan
            {
                Capital = param.Loan.Capital,
                CapitalToShow = param.Loan.Capital,
                Quote = param.Loan.Quote,
                RemainingPayments = param.Loan.Quote,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = CurrentUser.Name,
                Notes = param.Loan.Notes,
                ClientId = param.Loan.ClientId,
                TransactionTypeId = param.Loan.TransactionTypeId,
                TransactionPaymentId = param.Loan.TransactionPaymentId,
                ClientTypeId = param.Loan.ClientTypeId,
                TaxTypeId = param.Loan.TaxTypeId,
            };

            Database.Add(loan);

            foreach (var beneficiaryId in param.BeneficiaryIds)
            {
                var beneficiaryLoan = new BeneficiaryLoan
                {
                    BeneficiaryId = beneficiaryId,
                    Loan = loan
                };

                Database.Add(beneficiaryLoan);
            }

            await Database.SaveChangesAsync();

            result = await GetDetailById(loan.Id);

            return result;
        }

        public async Task<ServiceResult> PayLoan(PayLoanParameter param)
        {
            var result = ServiceResult.Create();

            var loanToPay = await Database.Loans
                .Include(l => l.Client)
                .FirstOrDefaultAsync(m => m.Id == param.LoanId);

            if (loanToPay == null)
            {
                result.AddErrorMessage("Este prestamo no existe");
                return result;
            }

            loanToPay.Capital = loanToPay.Capital - (long)param.Quote;
            loanToPay.RemainingPayments--;

            Database.Update(loanToPay);

            await Database.SaveChangesAsync();
            return result;
        }
    }

    public interface ILoanService : IService
    {
        Task<ServiceResult<List<LoanModel>>> GetAll();
        Task<ServiceResult<LoanModel>> GetDetailById(int id);
        Task<ServiceResult<LoanModel>> Create(CreateLoansModel param);
        Task<ServiceResult> PayLoan(PayLoanParameter param);
    }
}
