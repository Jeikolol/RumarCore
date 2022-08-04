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
        private readonly ILoanService _loanService;

        public HomeController(IClientService clientService, 
                              IBeneficiaryService beneficiaryService, 
                              ILoanService loanService)
        {
            _clientService = clientService;
            _beneficiaryService = beneficiaryService;
            _loanService = loanService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAll();
            var beneficiaries = await _beneficiaryService.GetAll();
            var loans = await _loanService.GetAll();

            var model = new DashboardModel
            {
                ClientsCount = clients.Data.Count(),
                BeneficiaryCount = beneficiaries.Data.Count(),
                LoansCount = loans.Data.Count()
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
