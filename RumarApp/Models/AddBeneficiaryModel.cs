using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RumarApp.Models
{
    public class AddBeneficiaryModel
    {
        public int BeneficiaryId { get; set; }
        public SelectList Beneficiaries { get; set; } = new SelectList(new List<string>());
    }
}
