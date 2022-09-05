using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RumarApp.Models
{
    [Authorize]
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [StringLength(60)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [StringLength(60)]
        public string LastName { get; set; }
        public string FullName => $"{FirstName + " " + LastName}";
        
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [StringLength(11)]
        public string Identification { get; set; }
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [StringLength(200)]
        public string Address { get; set; }
        public string PostalAddress { get; set; }
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        public string Nacionality { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public bool IsActive { get; set; }
        public ICollection<BeneficiaryModel> Beneficiaries { get; set; }
    }
}
