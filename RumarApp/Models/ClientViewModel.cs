using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Models
{
    public class ClientViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [StringLength(60)]
        public string FisrtName { get; set; }
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [StringLength(60)]
        public string LastName { get; set; }
        public string FullName => $"{FisrtName + " " + LastName}";
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [StringLength(12)]
        public string Identification { get; set; }
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [StringLength(200)]
        public string Address { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
