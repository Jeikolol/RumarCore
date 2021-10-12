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
using RumarApp.Parameters;
using RumarApp.Infraestructure;
using RumarApp.Services;
using Core.Entities;

namespace RumarApp.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        private readonly IBeneficiaryService _beneficiaryService;
        private readonly ApplicationDbContext _context;

        public ClientController(IClientService clientService, 
                                IBeneficiaryService beneficiaryService,
                                ApplicationDbContext context)
        {
            _clientService = clientService;
            _beneficiaryService = beneficiaryService;
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAllClients();

            return View(clients);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var clientViewModel = await _clientService.GetClientById(id);

            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View(clientViewModel);
        }

        public IActionResult Create()
        {
            ViewData["RelationshipTypeId"] = new SelectList(_context.RelationshipTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel param)
        {
            if (!ValidateHelper.IsValidDrCedula(param.Identification))
            {
                ShowNotification("La cedula ingresada no es valida", "Mantenimiento de Clientes", NotificationType.error);
                return View(param);
            }

            foreach (var item in param.Beneficiaries)
            {
                if (!ValidateHelper.IsValidDrCedula(item.Identification))
                {
                    ShowNotification("La cedula ingresada no es valida", "Mantenimiento de Clientes", NotificationType.error);
                    return View(param);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var client = await _clientService.Create(param);

                    return View("Details", client);
                }
                catch (Exception ex)
                {
                    ShowNotification(ex.InnerException.Message, "Mantenimiento de Clientes", NotificationType.error);
                    return View(param);
                }
              
            }

            return View(param);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var clientViewModel = await _clientService.GetClientById(id);

            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View(clientViewModel);
        }

        [HttpPost]
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
                    //await _clientService.Create(clientViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exist = await _clientService.GetClientById(clientViewModel.Id);
                   
                    if (exist == null)
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

        public async Task<IActionResult> Delete(int id)
        {
            var clientViewModel = await _clientService.GetClientById(id);

            if (clientViewModel == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteModal", clientViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientService.DeleteClient(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
