using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using RumarApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Models
{
    [Authorize]
    public class Loan
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public long Capital { get; set; } 
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public long CapitalToShow { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Interest { get; set; }
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal Quote { get; set; }
        public decimal RemainingPayments { get; set; }
        public DateTime CreationTime { get; set; }
        public string Notes { get; set; }
        public int ClientsId { get; set; }
        public virtual ClientViewModel Clients { get; set; }
        public int TransactionTypeId { get; set; } 
        public virtual TransactionType TransactionType { get; set; }
        public int TransactionPaymentId { get; set; }
        public virtual TransactionPayment TransactionPayment { get; set; }
        public int ClientTypeId { get; set; }
        public virtual ClientType ClientType { get; set; }
    }
}
