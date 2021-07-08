using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RumarApp.Data;
using RumarApp.Helpers;
using RumarApp.Models;

namespace RumarApp.Controllers
{
    public class LoansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Loan.Include(l => l.Clients);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .Include(l => l.Clients)
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
            ViewData["ClientsId"] = new SelectList(_context.ClientViewModel, "Id", "FisrtName");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Capital,Interest,Quote,ClientsId")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.CreationTime = DateTime.UtcNow;
                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientsId"] = new SelectList(_context.ClientViewModel, "Id", "FisrtName", loan.ClientsId);
            return View(loan);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            loan.Clients = await _context.ClientViewModel.FirstOrDefaultAsync(m=>m.Id == loan.ClientsId);

            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Capital,Interest,Quote,Clients,ClientsId")] Loan loan)
        {
            if (id != loan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientsId"] = new SelectList(_context.ClientViewModel, "Id", "FisrtName", loan.ClientsId);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .Include(l => l.Clients)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loan == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteModal", loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _context.Loan.FindAsync(id);
            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("DownloadReport")]
        public async Task<IActionResult> DownloadExcelDocument(int id)
        {
            var loan = await _context.Loan.FirstOrDefaultAsync(m=> m.Id == id);

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            string fileName = $"detalle del prestamo #{loan.Id} de {loan.CreationTime.ToString("dd/MM/yyyy")}.xlsx";
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    workbook.Properties.Author = "RumarApp";
                    workbook.Properties.Title = "";
                    workbook.Properties.Created = DateTime.UtcNow;

                    var worksheet = workbook.Worksheets.Add("Detalles del Prestamo");

                    var colPosition = 1;
                    var startInLine = 5;

                    var headerTitles = new List<string>
                    {
                        "#",
                        "Fecha de Pago",
                        "Cuota",
                        "Mora",
                        "Interes Mensual",
                        "Amortizacion Principal",
                        "Amortizacion Total",
                        "Capital Pendiente",
                    };

                    headerTitles.ForEach(t =>
                    {
                        worksheet.Cell(4, colPosition++).Value = t;

                        worksheet.Column(colPosition).Width = 18;
                        worksheet.Column(colPosition).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                        worksheet.Column(colPosition).Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                    });

                    double capital = loan.Capital;
                    double interest = Convert.ToDouble(loan.Interest) / 1200;
                    double plazo = Convert.ToDouble(loan.Quote);
                    DateTime paymentDate = loan.CreationTime;
                    DateTime nextDate = DateTime.UtcNow;

                    //Generate QuoteNumber

                    double quote = capital * (interest / (double)(1 - Math.Pow(1 + (double)interest, -plazo)));

                    double interest_monthly = 0;
                    double amortization = 0;
                    double amortization_total = 0;
                    double mora = 0;
                    int i = 1;

                    for (i = 1; i <= plazo; i++)
                    {
                        interest_monthly = (interest * capital);
                        capital = (capital - quote + interest_monthly);

                        //Amortizacion totales y principales

                        amortization_total += (quote - interest_monthly);
                        amortization = quote - interest_monthly;
                        paymentDate = nextDate.AddMonths(i);
                        mora = quote * (double)CalculatorHelper.percentageOneValue(0.05m);

                        worksheet.Cell(startInLine, 1).Value = i;
                        worksheet.Style.Font.Bold = true;
                        worksheet.Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                        
                        worksheet.Cell(startInLine, 2).Value = paymentDate.ToString("dd/MM/yyyy");
                        worksheet.Style.Font.Bold = true;
                        worksheet.Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                        
                        worksheet.Cell(startInLine, 3).Value = quote.ToString("C2");
                        worksheet.Style.Font.Bold = true;
                        worksheet.Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                        
                        worksheet.Cell(startInLine, 4).Value = mora.ToString("C2");
                        worksheet.Style.Font.Bold = true;
                        worksheet.Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                         
                        worksheet.Cell(startInLine, 5).Value = interest_monthly.ToString("C2");
                        worksheet.Style.Font.Bold = true;
                        worksheet.Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                         
                        worksheet.Cell(startInLine, 6).Value = amortization.ToString("C2");
                        worksheet.Style.Font.Bold = true;
                        worksheet.Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                        
                        worksheet.Cell(startInLine, 7).Value = amortization_total.ToString("C2");
                        worksheet.Style.Font.Bold = true;
                        worksheet.Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                         
                        worksheet.Cell(startInLine, 8).Value = capital.ToString("C2");
                        worksheet.Style.Font.Bold = true;
                        worksheet.Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);

                        startInLine++;
                    }

                    var stream = new MemoryStream();
                    workbook.SaveAs(stream);

                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.Id == id);
        }
    }
}
