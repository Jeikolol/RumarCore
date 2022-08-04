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
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [StringLength(60)]
        public string LastName { get; set; }
        public string FullName => $"{FirstName + " " + LastName}";
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [StringLength(12)]
        public string Identification { get; set; }
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [StringLength(200)]
        public string Address { get; set; }
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        public string PostalAddress { get; set; }
        [Required(ErrorMessage = "El Campo es {0} Obligatorio")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        public string Nacionality { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public Loan Loan { get; set; }
    }
}
