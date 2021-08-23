using System.ComponentModel.DataAnnotations;

namespace RumarApp.Enums
{
    public enum ClientTypeEnum
    {
        [Display(Name = "Cliente Recurrente")]
        RecurringCustomer = 1,
        [Display(Name = "Cliente Recomendado")]
        RecommendedCustomer,
        [Display(Name = "Cliente Nuevo")]
        NewCustomer
    }
}
