using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RumarApp.Models;
using RumarApp.Infraestructure;
using RumarApp.Services;
using Core.Entities;
using DatabaseMigrations.Data;

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
            var clients = await _clientService.GetAll();

            return View(clients.Data);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var clientViewModel = await _clientService.GetClientById(id);

            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View(clientViewModel.Data);
        }

        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Description");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel param)
        {
            //if (!ValidateHelper.IsValidDrCedula(param.Identification))
            //{
            //    ShowNotification("La cedula ingresada no es valida", "Mantenimiento de Clientes", NotificationType.error);
            //    return View(param);
            //}

            if (ModelState.IsValid)
            {
                var client = await _clientService.Create(param);

                if (!client.ExecutedSuccesfully)
                {
                    ShowNotification(client.Message, "Mantenimiento de Clientes", NotificationType.error);
                    return View(param);
                }

                ShowNotification("Cliente creado Correctamente", "Mantenimiento de Clientes", NotificationType.success);

                return RedirectToAction("Details", new { id = client.Data.Id });
            }

            return View(param);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var clientViewModel = await _clientService.GetClientById(id);

            if (!clientViewModel.ExecutedSuccesfully)
            {
                ShowNotification(clientViewModel.Message, "Mantenimiento de Clientes", NotificationType.error);
                return View(clientViewModel.Data);
            }

            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Description");

            return View(clientViewModel.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel clientViewModel)
        {
            var result = await _clientService.EditClient(clientViewModel);

            if (!result.ExecutedSuccesfully)
            {
                ShowNotification(result.Message, "Mantenimiento de Clientes", NotificationType.error);
                return View(clientViewModel);
            }
            
            return RedirectToAction("Details", new {id = clientViewModel.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var clientViewModel = await _clientService.GetClientById(id);

            if (clientViewModel == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteClientModal", clientViewModel.Data);
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
