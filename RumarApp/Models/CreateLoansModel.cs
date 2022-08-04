using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RumarApp.Models
{
    public class CreateLoansModel
    {
        public LoanModel Loan { get; set; }
        public List<int> BeneficiaryIds { get; set; } = new();
        public MultiSelectList Beneficiaries { get; set; } = new(new List<string>());
    }
}
