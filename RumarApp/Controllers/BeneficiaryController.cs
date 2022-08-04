using System;
using System.Threading.Tasks;
using Core.Entities;
using DatabaseMigrations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RumarApp.Infraestructure;
using RumarApp.Models;
using RumarApp.Services;

namespace RumarApp.Controllers
{
    public class BeneficiaryController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IBeneficiaryService _beneficiaryService;

        public BeneficiaryController(ApplicationDbContext context, 
            IBeneficiaryService beneficiaryService)
        {
            _context = context;
            _beneficiaryService = beneficiaryService;
        }

        // GET: Beneficiaries
        public async Task<IActionResult> Index()
        {
            var garantes = await _beneficiaryService.GetAll();
            return View(garantes.Data);
        }

        // GET: Beneficiaries/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var beneficiary= await _beneficiaryService.GetDetailsById(id);

            if (beneficiary == null)
            {
                return NotFound();
            }

            return View(beneficiary.Data);
        }

        // GET: Beneficiaries/Create
        public IActionResult Create()
        {
            ViewData["RelationshipTypeId"] = new SelectList(_context.RelationshipTypes, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Description");
            return View();
        }

        // POST: Beneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeneficiaryModel beneficiary)
        {
            if (ModelState.IsValid)
            {
                //if (!ValidateHelper.IsValidDrCedula(beneficiary.Identification))
                //{
                //    ShowNotification("La cedula ingresada no es valida", "Mantenimiento de Clientes", NotificationType.error);
                //    return View(beneficiary);
                //}

                var garante = await _beneficiaryService.Create(beneficiary);

                if (!garante.ExecutedSuccesfully)
                {
                    ShowNotification(garante.Message, "Mantenimiento de Garantes", NotificationType.error);
                    return View(garante.Data);
                }

                ShowNotification("Garante creado Correctamente", "Mantenimiento de Garantes", NotificationType.success);

                return RedirectToAction("Details", new { id = garante.Data.Id });
            }
            return View();
        }

        // GET: Beneficiaries/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["RelationshipTypeId"] = new SelectList(_context.RelationshipTypes, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Description");

            var beneficiary = await _beneficiaryService.GetDetailsById(id);

            if (beneficiary == null)
            {
                return NotFound();
            }

            return View(beneficiary.Data);
        }

        // POST: Beneficiaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BeneficiaryModel beneficiaryModel)
        {
            var result = await _beneficiaryService.Edit(beneficiaryModel);

            if (!result.ExecutedSuccesfully)
            {
                ShowNotification(result.Message, "Mantenimiento de Garantes", NotificationType.error);
                return View(beneficiaryModel);
            }

            return RedirectToAction("Details", new { id = beneficiaryModel.Id });
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

            return View();
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
    }
}
