using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RumarApp.Models;
using RumarApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IBeneficiaryService _beneficiaryService;
        //private readonly ILoanService _beneficiaryService;

        public HomeController(IClientService clientService, 
                              IBeneficiaryService beneficiaryService)
        {
            _clientService = clientService;
            _beneficiaryService = beneficiaryService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAllClients();

            var model = new DashboardModel
            {
                ClientsCount = clients.Count(),
                BeneficiaryCount = 0,
                LoansCount = 0
            };

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
