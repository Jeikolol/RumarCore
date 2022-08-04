using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RumarApp.Helpers;
using RumarApp.Models;
using RumarApp.Infraestructure;
using System.Dynamic;
using RumarApp.Enums;
using AspNetCoreHero.ToastNotification.Abstractions;
using Core.Entities;
using DatabaseMigrations.Data;
using RumarApp.Parameters;
using RumarApp.Services;

namespace RumarApp.Controllers
{
    [Authorize]
    public class LoansController : BaseController
    {
        private readonly ILoanService _loanService;
        private readonly ApplicationDbContext _context;
        private readonly IClientService _clientService;
        private readonly IBeneficiaryService _beneficiaryService;

        public LoansController(ApplicationDbContext context, 
            ILoanService loanService, 
            IClientService clientService, 
            IBeneficiaryService beneficiaryService)
        {
            _context = context;
            _loanService = loanService;
            _clientService = clientService;
            _beneficiaryService = beneficiaryService;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var loans = await _loanService.GetAll();

            return View(loans.Data);
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var loan = await _loanService.GetDetailById(id);

            if (loan == null)
            {
                return NotFound();
            }

            switch (loan.Data.TransactionPaymentId)
            {
                case (int)TransactionPaymentEnum.DailyPayment:
                    loan.Data.CalculateDailyPayment();
                    break;
                case (int)TransactionPaymentEnum.BiweeklyPayment:
                    loan.Data.CalculateBiweeklyPayment();
                    break;
                case (int)TransactionPaymentEnum.MonthlyPayment:
                    loan.Data.CalculateMonthlyPayment();
                    break;
            }

            return View(loan.Data);
        }

        // GET: Loans/Create
        public async Task<IActionResult> Create()
        {
            var beneficiary = await _beneficiaryService.GetAll();

            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "FullName");
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "Id", "Name");
            ViewData["TransactionPaymentId"] = new SelectList(_context.TransactionPayments, "Id", "Name");
            ViewData["ClientTypeId"] = new SelectList(_context.ClientTypes, "Id", "Name");
            ViewData["TaxTypeId"] = new SelectList(_context.TaxTypes, "Id", "Name");

            var model = new CreateLoansModel
            {
                Beneficiaries = beneficiary.Data.ToMultiSelectList(x=>x.Id, x => x.FullName)
            };

            return View(model);
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(CreateLoansModel param)
        {
            if (ModelState.IsValid)
            {
                var result = await _loanService.Create(param);
                
                if (!result.ExecutedSuccesfully)
                {
                    ShowNotification(result.Message, "Mantenimiento de Prestamos", NotificationType.error);
                    return View(param);
                }

                ShowNotification("Prestamo creado Correctamente", "Mantenimiento de Prestamos", NotificationType.success);
                
                return RedirectToAction("Details", new {id = result.Data.Id});
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var loan = await _loanService.GetDetailById(id);

            if (loan == null)
            {
                return NotFound();
            }

            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "FullName");
            
            //loan.Data.Client = await _clientService.GetClientById(loan.Data.ClientId);
            //loan.Data.TransactionPayment = await _context.TransactionPayments.FirstOrDefaultAsync(m=>m.Id == loan.Data.TransactionPaymentId);
            //loan.Data.TransactionType = await _context.TransactionTypes.FirstOrDefaultAsync(m=>m.Id == loan.Data.TransactionTypeId);

            return View(loan.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Loan param)
        {
            if (id != param.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loanToUpdate = await _context.Loans.FindAsync(id);
                  
                    param.ClientId = loanToUpdate.ClientId;

                    _context.Update(param);
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!LoanExists(param.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }

            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "FirstName", param.ClientId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "Id", "Name", param.TransactionTypeId);
            ViewData["TransactionPaymentId"] = new SelectList(_context.TransactionPayments, "Id", "Name", param.TransactionPaymentId);

            return View();
        }

        public async Task<IActionResult> PayModal(PayLoanParameter loanPay)
        {
            var payLoan = new PayLoanParameter
            {
                LoanId = loanPay.LoanId,
                Client = loanPay.Client,
            };

            return PartialView("_PaymentLoanModal", payLoan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayLoan(PayLoanParameter loanPay)
        {
            var loanToPay = await _context.Loans
                .Include(l => l.Client)
                .FirstOrDefaultAsync(m => m.Id == loanPay.LoanId);

            if (loanToPay == null)
            {
                return NotFound();
            }

            loanToPay.Capital = loanToPay.Capital - (long)loanPay.Quote;
            loanToPay.RemainingPayments--;

            _context.Loans.Update(loanToPay);
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddBeneficiaryToLoan(BeneficiaryModel beneficiary)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //if (!ValidateHelper.IsValidDrCedula(beneficiary.Identification))
        //        //{
        //        //    ShowNotification("La cedula ingresada no es valida", "Mantenimiento de Clientes", NotificationType.error);
        //        //    return View(beneficiary);
        //        //}

        //        var garante = await _beneficiaryService.Create(beneficiary);

        //        if (!garante.ExecutedSuccesfully)
        //        {
        //            ShowNotification(garante.Message, "Mantenimiento de Garantes", NotificationType.error);
        //            return View(garante.Data);
        //        }

        //        ShowNotification("Garante creado Correctamente", "Mantenimiento de Garantes", NotificationType.success);

        //        return RedirectToAction("Details", new { id = garante.Data.Id });
        //    }

        //    return View();
        //}

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.Id == id);
        }
        
        private bool BeneficiaryExistByIdentification(string identification)
        {
            return _context.Beneficiaries.Any((System.Linq.Expressions.Expression<Func<Beneficiary, bool>>)(e => e.Identification == identification));
        }
    }
}
