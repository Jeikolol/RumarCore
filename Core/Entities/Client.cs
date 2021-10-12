using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    [Authorize]
    public class Client : Entity
    {
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
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
    }
}
