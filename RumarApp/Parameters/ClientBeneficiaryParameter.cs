using RumarApp.Models;
using System.Collections.Generic;

namespace RumarApp.Parameters
{
    public class ClientBeneficiaryParameter
    {
        public ClientViewModel Client { get; set; }
        public List<BeneficiaryModel> Beneficiary { get; set; }
    }
}
