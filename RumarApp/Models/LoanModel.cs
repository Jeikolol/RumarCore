using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
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
        public virtual ClientViewModel Clients { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TransactionTypeId { get; set; }
        public virtual TransactionTypeModel TransactionType { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TransactionPaymentId { get; set; }
        public virtual TransactionPaymentModel TransactionPayment { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClientTypeId { get; set; }
        public virtual ClientTypeModel ClientType { get; set; }
        public virtual ICollection<BeneficiaryModel> Beneficiary { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsFullPaid { get; set; }
    }
}
