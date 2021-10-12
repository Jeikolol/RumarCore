using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RumarApp.Data;
using RumarApp.Models;

namespace RumarApp.Controllers
{
    public class BeneficiariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Beneficiaries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.Beneficiaries.ToListAsync();
            return View(applicationDbContext);
        }

        // GET: Beneficiaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries
                .FirstOrDefaultAsync((System.Linq.Expressions.Expression<Func<Beneficiary, bool>>)(m => m.Id == id));

            if (beneficiary == null)
            {
                return NotFound();
            }

            return View(beneficiary);
        }

        // GET: Beneficiaries/Create
        public IActionResult Create()
        {
            ViewData["RelationshipTypeId"] = new SelectList(_context.RelationshipTypes, "Id", "Id");
            return View();
        }

        // POST: Beneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Beneficiary beneficiary)
        {
            if (ModelState.IsValid)
            {
                //beneficiary.CreationDateTime = DateTime.Today;
                //beneficiary.CreatedBy = User.Identity.Name;

                _context.Add(beneficiary);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(beneficiary);
        }

        // GET: Beneficiaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            return View(beneficiary);
        }

        // POST: Beneficiaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FisrtName,LastName,Identification,Address,PhoneNumber,MobileNumber,RelationshipTypeId,IsDeleted,DeletedDate,DeletedBy,DeletedReason,CreatedBy,CreationDateTime")] Beneficiary beneficiary)
        {
            if (id != beneficiary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiaryExists(beneficiary.Id))
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
            return View(beneficiary);
        }

        // GET: Beneficiaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries
                .FirstOrDefaultAsync((System.Linq.Expressions.Expression<Func<Beneficiary, bool>>)(m => m.Id == id));

            if (beneficiary == null)
            {
                return NotFound();
            }

            return View(beneficiary);
        }

        // POST: Beneficiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            _context.Beneficiaries.Remove(beneficiary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficiaryExists(int id)
        {
            return _context.Beneficiaries.Any((System.Linq.Expressions.Expression<Func<Beneficiary, bool>>)(e => e.Id == id));
        }
    }
}
