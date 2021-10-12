using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TransactionPayment : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
