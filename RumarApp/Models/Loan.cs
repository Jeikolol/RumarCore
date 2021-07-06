using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public long Capital { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Interest { get; set; }
        public decimal Quote { get; set; }
        public DateTime CreationTime { get; set; }
        public string Notes { get; set; }
        public int ClientsId { get; set; }
        public virtual ClientViewModel Clients { get; set; }
    }
}
