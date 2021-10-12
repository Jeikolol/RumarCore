using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TaxType : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }
    }
}
