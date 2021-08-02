using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reactive;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RumarApp.Data;
using RumarApp.Helpers;
using RumarApp.Models;

namespace RumarApp.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index(string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {
           
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
           
            ViewData["CurrentFilter"] = searchString;

            var clients = from s in _context.Client
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.FisrtName.Contains(searchString) ||
                                        s.LastName.Contains(searchString) || s.Identification.Contains(searchString) ||
                                        s.Address.Contains(searchString) || s.PhoneNumber.Contains(searchString));
            }

            clients = clients.OrderBy(s => s.FisrtName);

            int pageSize = 5;

            return View(await PaginatedList<ClientViewModel>.CreateAsync(clients.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View(clientViewModel);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel clientViewModel)
        {
            if (!ValidateHelper.IsValidDrCedula(clientViewModel.Identification))
            {
                ModelState.AddModelError(nameof(clientViewModel.Identification), "La cedula ingresada no es valida");
                return View(clientViewModel);
            }

            if (ModelState.IsValid)
            {
                _context.Add(clientViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientViewModel);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.Client.FindAsync(id);
            if (clientViewModel == null)
            {
                return NotFound();
            }
            return View(clientViewModel);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientViewModelExists(clientViewModel.Id))
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
            return View(clientViewModel);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);

            if (clientViewModel == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteModal", clientViewModel);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientViewModel = await _context.Client.FindAsync(id);
            _context.Client.Remove(clientViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientViewModelExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
