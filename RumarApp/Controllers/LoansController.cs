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
using RumarApp.Data;
using RumarApp.Helpers;
using RumarApp.Models;
using RumarApp.Infraestructure;
using System.Dynamic;
using RumarApp.Enums;
using AspNetCoreHero.ToastNotification.Abstractions;
using Core.Entities;

namespace RumarApp.Controllers
{
    [Authorize]
    public class LoansController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public LoansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var loans = await _context.Loans
                    .Include(l => l.Clients)
                    .Include(l => l.TransactionPayment)
                    .Include(l => l.TransactionType)
                    .ToListAsync();

            return View(loans);
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Clients)
                .Include(l => l.TransactionPayment)
                .Include(l => l.TransactionType)
                .Include(l => l.Beneficiary)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "FullName");
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "Id", "Name");
            ViewData["TransactionPaymentId"] = new SelectList(_context.TransactionPayments, "Id", "Name");
            ViewData["ClientTypeId"] = new SelectList(_context.ClientTypes, "Id", "Name");
            
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLoansModel param)
        {
            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "FisrtName", param.Loan.ClientsId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "Id", "Name", param.Loan.TransactionTypeId);
            ViewData["TransactionPaymentId"] = new SelectList(_context.TransactionPayments, "Id", "Name", param.Loan.TransactionPaymentId);
            ViewData["ClientTypeId"] = new SelectList(_context.ClientTypes, "Id", "Name", param.Loan.ClientTypeId);

            if (ModelState.IsValid)
            {
                var loan = new Loan();

                if (param.Beneficiary.Identification == null)
                {
                    loan.Capital = param.Loan.Capital;
                    loan.CapitalToShow = param.Loan.Capital;
                    loan.Interest = param.Loan.Interest;
                    loan.Quote = param.Loan.Quote;
                    loan.RemainingPayments = param.Loan.Quote;
                    loan.CreationTime = DateTime.UtcNow;
                    loan.Notes = param.Loan.Notes;
                    loan.ClientsId = param.Loan.ClientsId;
                    loan.TransactionTypeId = param.Loan.TransactionTypeId;
                    loan.TransactionPaymentId = param.Loan.TransactionPaymentId;
                    loan.ClientTypeId = param.Loan.ClientTypeId;
                }
                else
                {
                    loan.Capital = param.Loan.Capital;
                    loan.CapitalToShow = param.Loan.Capital;
                    loan.Interest = param.Loan.Interest;
                    loan.Quote = param.Loan.Quote;
                    loan.RemainingPayments = param.Loan.Quote;
                    loan.CreationTime = DateTime.UtcNow;
                    loan.Notes = param.Loan.Notes;
                    loan.ClientsId = param.Loan.ClientsId;
                    loan.TransactionTypeId = param.Loan.TransactionTypeId;
                    loan.TransactionPaymentId = param.Loan.TransactionPaymentId;
                    loan.ClientTypeId = param.Loan.ClientTypeId;
                }

                
                if (param.Loan.ClientTypeId != (int)ClientTypeEnum.RecurringCustomer && param.Beneficiary.Identification == null)
                {
                    ShowNotification("Debe agregar un Garante.", "Mantenimiento de Prestamos", NotificationType.error);
                    return View(param);
                }
                else
                {
                    if (param.Beneficiary.Identification != null)
                    {

                        if (BeneficiaryExistByIdentification(param.Beneficiary.Identification))
                        {
                            ShowNotification("Esta persona ya es Garante de otro Prestamo", "Mantenimiento de Prestamos", NotificationType.error);
                            return View(param);
                        }
                        else
                        {
                            var beneficiary = new Beneficiary
                            {
                                FisrtName = param.Beneficiary.FisrtName,
                                LastName = param.Beneficiary.LastName,
                                Identification = param.Beneficiary.Identification,
                                Address = param.Beneficiary.Address,
                                PhoneNumber = param.Beneficiary.PhoneNumber,
                                MobileNumber = param.Beneficiary.MobileNumber
                            };

                            _context.Add(beneficiary);
                        }
                    }

                    _context.Add(loan);

                    await _context.SaveChangesAsync();
                }

            }

            ShowNotification("Prestamo creado Correctamente", "Mantenimiento de Prestamos", NotificationType.success);

            return RedirectToAction(nameof(Index));
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Clients)
                .Include(l => l.TransactionPayment)
                .Include(l => l.TransactionType)
                .Include(l => l.Beneficiary)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "FullName");
            
            loan.Clients = await _context.Clients.FirstOrDefaultAsync(m=>m.Id == loan.ClientsId);
            loan.TransactionPayment = await _context.TransactionPayments.FirstOrDefaultAsync(m=>m.Id == loan.TransactionPaymentId);
            loan.TransactionType = await _context.TransactionTypes.FirstOrDefaultAsync(m=>m.Id == loan.TransactionTypeId);

            return View(loan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                  
                    param.ClientsId = loanToUpdate.ClientsId;

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

            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "FisrtName", param.ClientsId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "Id", "Name", param.TransactionTypeId);
            ViewData["TransactionPaymentId"] = new SelectList(_context.TransactionPayments, "Id", "Name", param.TransactionPaymentId);

            return View(param);
        }

        public async Task<IActionResult> PayLoan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Clients)
                .FirstOrDefaultAsync(m => m.Id == id);

            var payLoan = new PayLoanParameter
            {
                LoanId = loan.Id,
                Client = loan.Clients.FullName,
            };

            if (loan == null)
            {
                return NotFound();
            }

            return PartialView("_PaymentLoanModal", payLoan);
        }

        [HttpPost, ActionName("Pay")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay(int id, PayLoanParameter loanPay)
        {
            var loanToPay = await _context.Loans
                .Include(l => l.Clients)
                .FirstOrDefaultAsync(m => m.Id == id);

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
