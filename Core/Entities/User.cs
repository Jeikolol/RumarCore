
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El Nombre no puede tener mas de 20 caracteres")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        [MaxLength(20, ErrorMessage = "El apellido no puede tener mas de 20 caracteres")]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Required(ErrorMessage = "La Cedula es requerida")]
        [RegularExpression(@"\d{11}")]
        public string Identification { get; set; }
        [Required(ErrorMessage = "La Direccion es Requerida.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "El Telefono es Requerido.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
    }
}
