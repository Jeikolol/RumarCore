using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La confirmacion es diferente a la orignal.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El Nombre no puede tener mas de 20 caracteres")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        [MaxLength(20, ErrorMessage = "El apellido no puede tener mas de 20 caracteres")]
        public string LastName { get; set; }
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
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
