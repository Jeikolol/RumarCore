using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    [Authorize]
    public class Loan : Entity
    {
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Capital { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal CapitalToShow { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal Quote { get; set; }
        public decimal RemainingPayments { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TransactionTypeId { get; set; } 
        public TransactionType TransactionType { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TransactionPaymentId { get; set; }
        public TransactionPayment TransactionPayment { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClientTypeId { get; set; }
        public ClientType ClientType { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsFullPaid { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TaxTypeId { get; set; }
        public TaxType TaxType { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public ICollection<BeneficiaryLoan> BeneficiaryLoan { get; set; }
    }
}
