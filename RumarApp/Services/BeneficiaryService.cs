using RumarApp.Data;
using RumarApp.Infraestructure;
using RumarApp.Models;
using RumarApp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Services
{
    public class BeneficiaryService : Service, IBeneficiaryService
    {
        private readonly IClientService _clientService;

        public BeneficiaryService(ApplicationDbContext database, IClientService clientService) : base(database)
        {
            _clientService = clientService;
        }

    }

    public interface IBeneficiaryService: IService 
    {
    }
}
