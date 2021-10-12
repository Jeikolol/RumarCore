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
        public long Capital { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public long CapitalToShow { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Interest { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal Quote { get; set; }
        public decimal RemainingPayments { get; set; }
        public DateTime CreationTime { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClientsId { get; set; }
        public virtual Client Clients { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TransactionTypeId { get; set; } 
        public virtual TransactionType TransactionType { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TransactionPaymentId { get; set; }
        public virtual TransactionPayment TransactionPayment { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClientTypeId { get; set; }
        public virtual ClientType ClientType { get; set; }
        public virtual ICollection<Beneficiary> Beneficiary { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsFullPaid { get; set; }
    }
}
